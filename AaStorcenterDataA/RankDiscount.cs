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
    
    public partial class RankDiscount
    {
        public int RDID { get; set; }
        public System.DateTime RDStartDate { get; set; }
        public System.DateTime RDEndDate { get; set; }
        public int ItemID { get; set; }
        public int RankID { get; set; }
        public int StoreID { get; set; }
    
        public virtual ItemTable ItemTable { get; set; }
        public virtual RankTable RankTable { get; set; }
        public virtual Store Store { get; set; }
    }
}
