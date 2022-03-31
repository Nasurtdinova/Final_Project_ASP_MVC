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
    
    public partial class Command
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Command()
        {
            this.ResultCompetition = new HashSet<ResultCompetition>();
            this.SponsorCommand = new HashSet<SponsorCommand>();
            this.Sportsman = new HashSet<Sportsman>();
        }
    
        public int idCommand { get; set; }
        public string Name { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> idImage { get; set; }
        public Nullable<int> ID_city { get; set; }
        public byte[] Image { get; set; }
    
        public virtual City City { get; set; }
        public virtual Images Images { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultCompetition> ResultCompetition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SponsorCommand> SponsorCommand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sportsman> Sportsman { get; set; }
    }
}
