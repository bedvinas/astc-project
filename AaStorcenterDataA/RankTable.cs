//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AaStorcenterDataA
{
    using System;
    using System.Collections.Generic;
    
    public partial class RankTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RankTable()
        {
            this.RankDiscounts = new HashSet<RankDiscount>();
            this.UserTables = new HashSet<UserTable>();
        }
    
        public int RankID { get; set; }
        public string RankName { get; set; }
        public string RankDescription { get; set; }
        public int PointsNeeded { get; set; }
        public int StoreID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RankDiscount> RankDiscounts { get; set; }
        public virtual Store Store { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
