using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class Commands
    {
        [Required(ErrorMessage = "Id is required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Name command is required")]
        public string Name { get; set; }

        public string Image { get; set; }

        [Range(1, 10)]
        public int Count { get; set; }

        public override string ToString()
        {
            return $"{ID},{Name} {City} {Count}";
        }
    }
}
