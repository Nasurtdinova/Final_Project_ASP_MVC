using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Models
{
    public class User
    {
        [Required(ErrorMessage = "Id is required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(16, ErrorMessage = "Must be between 2 and 16 characters", MinimumLength = 2)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(100, ErrorMessage = "Password must be between 4 and 100 characters", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(100, ErrorMessage = "Password must be between 4 and 100 characters", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Range(1940, 2010)]
        public int Year { get; set; }

        public int idType { get; set; }
    }
}
