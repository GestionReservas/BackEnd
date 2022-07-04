using Entities;
using Entities.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class ReservationRepository : IReservationRepository
    {

        private readonly DataBaseContext _dataBaseContext;


        public ReservationRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;

        }
             

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await (from user in _dataBaseContext.Users
                          join reservation in _dataBaseContext.Reservations on user.Id equals reservation.UserId
                          join workSpace in _dataBaseContext.WorkSpaces on reservation.SpaceId equals workSpace.Id
                          select new Reservation
                          {
                              Id = reservation.Id,
                              SpaceId = reservation.SpaceId,
                              Date = reservation.Date,
                              UserId = reservation.UserId,
                              User = user,
                              WorkSpace = workSpace

                          }).ToListAsync();
        }

        public async Task<Reservation> Create(Reservation reservation)
        {
            var department = _dataBaseContext.WorkSpaces;


            var filterBitwork = department.Where(x => x.Company.Equals("bitwok"));
            var filterMarketing = department.Where(x => x.Company.Equals("marketing"));

            var now = ((TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"))));


            //if (personBitwork == filterBitwork || personMarketing == filterMarketing )
            //{

            //    if (now.DayOfWeek == DayOfWeek.Friday)
            //    {
            //        booking = new DateTime(now.Year, now.Month, now.Day + 4);

            //    }               
            //    else
            //    {
            //        booking = new DateTime(now.Year, now.Month, now.Day + 2);

            //    }

            //}
            //else
            //{
            //    if (now.DayOfWeek == DayOfWeek.Friday)
            //    {
            //        booking = new DateTime(now.Year, now.Month, now.Day + 3);

            //    }                
            //    else
            //    {
            //        booking = new DateTime(now.Year, now.Month, now.Day + 1);

            //    }


            //}

            _dataBaseContext.Add(reservation);
            await _dataBaseContext.SaveChangesAsync();
            return reservation;

        }
    }
}

