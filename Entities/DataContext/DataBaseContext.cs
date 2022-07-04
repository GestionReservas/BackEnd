using Entities.Aut;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataContext
{
    //public class DataBaseContext : DbContext
    public class DataBaseContext : IdentityDbContext<ApplicationUser>
    { 
     public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

      

        // dotnet ef migrations add Authentication. para pasar la cadena de migration en la consola dotnet ef migrations add Authentication, ejecutar y luego activar el constructor anterior
        //luego dotnet ef database update actualizamos la base de datos

      /*protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
           {
               dbContextOptionsBuilder.UseSqlServer("Data Source= LAPTOP-SL4OFHD4\\SQLEXPRESS;Initial Catalog=DB_2;Integrated Security=True");

           }*/
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<WorkSpace> WorkSpaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservation>()
                           .HasOne(x => x.WorkSpace);

            modelBuilder.Entity<WorkSpace>()
                .HasMany(x => x.Reservations);
        }
    }
}
