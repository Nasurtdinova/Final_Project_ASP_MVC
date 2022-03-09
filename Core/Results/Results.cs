using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class Results
    {
        [Required(ErrorMessage = "Id command is required")]
        public int idCommand { get; set; }

        [Required(ErrorMessage = "Id competition is required")]
        public int idCompet { get; set; }

        [Required(ErrorMessage = "Name command is required")]
        public string Command { get; set; }

        [Required(ErrorMessage = "Name competition is required")]
        public string Compet { get; set; }

        [Required(ErrorMessage = "Range is required")]
        [Range(1, 100, ErrorMessage = "Недопустимое место")]
        public int Rank { get; set; }

        public override string ToString()
        {
            return $"{idCommand},{idCompet},{Command} {Compet} {Rank}";
        }
    }
}
