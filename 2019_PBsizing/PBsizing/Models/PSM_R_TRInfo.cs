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
    
    public partial class PSM_R_TRInfo
    {
        public PSM_R_TRInfo()
        {
            this.PSM_R_TRDetail = new HashSet<PSM_R_TRDetail>();
        }
    
        public long tr_LID { get; set; }
        public Nullable<long> tr_iRRevID { get; set; }
        public string tr_ConfNm { get; set; }
        public string tr_TRName { get; set; }
        public Nullable<System.DateTime> tr_Date { get; set; }
        public string tr_TesterNm { get; set; }
        public string tr_Cust_Model { get; set; }
        public string tr_Cmnt { get; set; }
        public Nullable<int> tr_Rnk { get; set; }
        public string tr_stat { get; set; }
        public string tr_manuals { get; set; }
        public string tr_DTP { get; set; }
    
        public virtual ICollection<PSM_R_TRDetail> PSM_R_TRDetail { get; set; }
    }
}
