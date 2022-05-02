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

    public partial class Sportsman
    {
        [Required(ErrorMessage = "Id is required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(16, ErrorMessage = "Must be between 2 and 16 characters", MinimumLength = 2)]
        public string Name { get; set; }

        public Nullable<int> idTitle { get; set; }

        [Range(150, 210)]
        public Nullable<int> Height { get; set; }

        [Required(ErrorMessage = "Command is required")]
        public Nullable<int> idCommand { get; set; }

        public byte[] Image { get; set; }

        public Nullable<bool> IsDeleted { get; set; }
       
        public virtual Command Command { get; set; }

        public virtual Title Title { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Surname}, {Title.Name}, {Height}, {Command.Name}";
        }
    }
}
