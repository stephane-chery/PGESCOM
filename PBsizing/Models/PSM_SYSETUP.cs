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
    
    public partial class PSM_SYSETUP
    {
        public long id { get; set; }
        public string VER { get; set; }
        public string BLD { get; set; }
        public string s_msg { get; set; }
        public string s_machNm { get; set; }
        public string s_stat { get; set; }
        public string NewQ { get; set; }
        public string NewR { get; set; }
        public string IpAdrs { get; set; }
        public Nullable<long> IPport { get; set; }
        public Nullable<System.DateTime> date_IN { get; set; }
        public Nullable<int> DFM { get; set; }
    }
}
