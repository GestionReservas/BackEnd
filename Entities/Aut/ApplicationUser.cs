using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Aut
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string RepeatPassword { get; set; }
       
        public string Avatar { get; set; }

        public string Company { get; set; }
    }
}
