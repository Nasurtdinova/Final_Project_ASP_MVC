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
    
    public partial class Competition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competition()
        {
            this.ResultCompetition = new HashSet<ResultCompetition>();
        }
    
        public int idCompetition { get; set; }
        public string Name { get; set; }
        public string NameVenue { get; set; }
        public string Street { get; set; }
        public Nullable<int> Home { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> idCity { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual City City { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultCompetition> ResultCompetition { get; set; }
    }
}
