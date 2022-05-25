//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ResultCompetition
    {
        [Required(ErrorMessage = "Name command is required")]
        public Nullable<int> idCommand { get; set; }

        [Required(ErrorMessage = "Name competition is required")]
        public Nullable<int> idCompetition { get; set; }

        [Required(ErrorMessage = "Range is required")]
        [Range(1, 100, ErrorMessage = "Недопустимое место")]
        public Nullable<int> Rank { get; set; }
    
        public virtual Command Command { get; set; }

        public virtual Competition Competition { get; set; }

        public override string ToString()
        {
            return $"{idCommand},{idCompetition},{Command.Name} {Competition.Name} {Rank}";
        }
    }
}
