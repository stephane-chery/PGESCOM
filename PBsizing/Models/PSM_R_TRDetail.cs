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
    
    public partial class PSM_R_TRDetail
    {
        public long d_trDetLID { get; set; }
        public Nullable<long> d_TR_LID { get; set; }
        public string d_TR_Tname { get; set; }
        public string d_TR_Ttyp { get; set; }
        public string d_TR_Tstat { get; set; }
        public string d_TecVALreq { get; set; }
        public string d_TecVALTST { get; set; }
        public string d_TR_Cmnt { get; set; }
        public Nullable<int> d_TR_Rnk { get; set; }
    
        public virtual PSM_R_TRInfo PSM_R_TRInfo { get; set; }
    }
}
