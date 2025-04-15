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
    
    public partial class PSM_R_SBills
    {
        public PSM_R_SBills()
        {
            this.PSM_R_SBillsPaid = new HashSet<PSM_R_SBillsPaid>();
            this.PSM_R_SBillsDetail = new HashSet<PSM_R_SBillsDetail>();
        }
    
        public long Bil_LID { get; set; }
        public Nullable<long> b_RRevLID { get; set; }
        public string BilNm { get; set; }
        public string SoldTo { get; set; }
        public string Cpmny_SoldTo { get; set; }
        public Nullable<System.DateTime> InvoicDat { get; set; }
        public string CustAcct { get; set; }
        public string AccInv { get; set; }
        public string Terms { get; set; }
        public string CCnb { get; set; }
        public string IncoTerm { get; set; }
        public string b_via { get; set; }
        public Nullable<double> FReight { get; set; }
        public string b_Cmnt { get; set; }
        public Nullable<double> BilTOT { get; set; }
        public string FOB { get; set; }
        public Nullable<double> AmntPaid { get; set; }
        public string BilStatus { get; set; }
        public Nullable<double> TPS_tx { get; set; }
        public Nullable<double> TVQ_tx { get; set; }
        public Nullable<double> TVH_tx { get; set; }
        public Nullable<double> BigTot { get; set; }
        public Nullable<double> OTH_Fees { get; set; }
        public string b_TaxID { get; set; }
        public Nullable<int> b_Rnk { get; set; }
        public Nullable<int> TPS_tx_code { get; set; }
        public Nullable<int> TVQ_tx_code { get; set; }
        public Nullable<int> TVH_tx_code { get; set; }
        public string s_weight { get; set; }
        public string s_HS { get; set; }
        public string Cust_brkr { get; set; }
        public Nullable<double> Xchng_rate { get; set; }
        public string Com { get; set; }
    
        public virtual ICollection<PSM_R_SBillsPaid> PSM_R_SBillsPaid { get; set; }
        public virtual ICollection<PSM_R_SBillsDetail> PSM_R_SBillsDetail { get; set; }
    }
}
