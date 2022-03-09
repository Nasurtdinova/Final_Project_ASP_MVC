using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class Sponsorships
    {
        [Required(ErrorMessage = "Id is required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Sponsor name is required")]
        public string SponsorName { get; set; }

        [Required(ErrorMessage = "Sponsor surname is required")]
        public string SponsorSurname { get; set; }

        [Required(ErrorMessage = "Name command is required")]
        public string Command { get; set; }

        [Range(1, 10)]
        public int teamContract { get; set; }

        [Range(500, 500000)]
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{ID},{SponsorName} - {Command}, {Amount}, {teamContract}";
        }
    }
}
