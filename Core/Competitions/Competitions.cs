using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class Competitions
    {
        [Required(ErrorMessage = "Id is required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name competition is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name venue is required")]
        public string NameVenue { get; set; }

        public string Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        public int Home { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{ID},{Name} {NameVenue} {Street} {Home} {City} {Date}";
        }
    }
}
