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
    
    public partial class Sportsman
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public Nullable<int> ID_Image { get; set; }
        public Nullable<int> idTitle { get; set; }
        public Nullable<int> Cost { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> idCommand { get; set; }
    
        public virtual Title Title { get; set; }
        public virtual Command Command { get; set; }
        public virtual Images Images { get; set; }
    }
}
