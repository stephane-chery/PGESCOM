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
    
    public partial class PSM_Q_ALS
    {
        public long ALS_LID { get; set; }
        public Nullable<long> SPC_LID { get; set; }
        public string ALS_Name { get; set; }
        public Nullable<double> Tot { get; set; }
        public Nullable<byte> Rnk { get; set; }
        public Nullable<double> PxPrice { get; set; }
        public Nullable<double> AGPrice { get; set; }
        public Nullable<double> AlsQty { get; set; }
        public Nullable<bool> SV_Ovrg { get; set; }
        public string Diag { get; set; }
    }
}
