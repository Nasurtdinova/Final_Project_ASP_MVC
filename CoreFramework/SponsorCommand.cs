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
    
    public partial class SponsorCommand
    {
        public int id { get; set; }
        public Nullable<int> idSponsor { get; set; }
        public Nullable<int> idCom { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public Nullable<System.DateTime> DateBegin { get; set; }
        public Nullable<int> idStatus { get; set; }
        public string MutualBenefit { get; set; }
    
        public virtual Sponsor Sponsor { get; set; }
        public virtual Status Status { get; set; }
        public virtual Command Command { get; set; }
    }
}
