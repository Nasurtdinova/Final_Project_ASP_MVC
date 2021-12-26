using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Year { get; set; }
    }
}
