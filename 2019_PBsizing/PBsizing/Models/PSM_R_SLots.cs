//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBsizing.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PSM_R_SLots
    {
        public PSM_R_SLots()
        {
            this.PSM_R_SLotsDetail = new HashSet<PSM_R_SLotsDetail>();
        }
    
        public long LotslID { get; set; }
        public Nullable<long> l_RRevLID { get; set; }
        public Nullable<long> l_invLID { get; set; }
        public string LotNm { get; set; }
        public string car_TRKnb { get; set; }
        public string PX_TRKnb { get; set; }
        public Nullable<System.DateTime> ShipDat { get; set; }
        public Nullable<int> CarrierLID { get; set; }
        public string Acct_Carrier { get; set; }
        public string Cust_acct_car { get; set; }
        public string Tag { get; set; }
        public string Cust_brkr { get; set; }
        public string ShipTo { get; set; }
        public string ShipTo_cpny { get; set; }
        public string shp_ContactNme { get; set; }
        public string shp_ContactTEL { get; set; }
        public string s_Cmnt { get; set; }
        public string ShStatus { get; set; }
        public Nullable<int> s_Rnk { get; set; }
        public string s_weight { get; set; }
        public string s_HS { get; set; }
    
        public virtual ICollection<PSM_R_SLotsDetail> PSM_R_SLotsDetail { get; set; }
    }
}
