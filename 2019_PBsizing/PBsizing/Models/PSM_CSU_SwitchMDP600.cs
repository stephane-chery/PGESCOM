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
    
    public partial class PSM_CSU_SwitchMDP600
    {
        public int IDline { get; set; }
        public string P600_phs1 { get; set; }
        public string P600_phs3 { get; set; }
        public string Enc { get; set; }
        public Nullable<decimal> Enc_PU { get; set; }
        public Nullable<int> modul_NB { get; set; }
        public string ShelfQty { get; set; }
        public string BlankQty { get; set; }
        public string Subrack { get; set; }
        public Nullable<decimal> Subrack_PU { get; set; }
        public Nullable<decimal> INPUT_Curr_p1 { get; set; }
        public decimal INPUT_Curr_p3 { get; set; }
        public string BreakerRU { get; set; }
        public string RU { get; set; }
        public Nullable<decimal> Model_PU { get; set; }
        public Nullable<byte> brkr_Warn { get; set; }
    }
}
