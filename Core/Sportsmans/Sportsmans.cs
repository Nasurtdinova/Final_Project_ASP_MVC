using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Sportsmans
    {
        [Required(ErrorMessage = "Id is required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(16, ErrorMessage = "Must be between 2 and 16 characters", MinimumLength = 2)]
        public string Name { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        [Range(150, 210)]
        public int Height { get; set; }

        public int Cost { get; set; }

        [Required(ErrorMessage = "Name command is required")]
        public string Command { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Surname}, {Title}, {Height}, {Cost}, {Command}";
        }
    }
}
