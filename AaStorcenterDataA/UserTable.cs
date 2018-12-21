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
    
    public partial class UserTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserTable()
        {
            this.TransactionTables = new HashSet<TransactionTable>();
        }
    
        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public int UserPoints { get; set; }
        public int UserPointsSpent { get; set; }
        public int AccRoleID { get; set; }
        public int RankID { get; set; }
        public int StoreID { get; set; }
    
        public virtual AccRole AccRole { get; set; }
        public virtual RankTable RankTable { get; set; }
        public virtual Store Store { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionTable> TransactionTables { get; set; }
    }
}
