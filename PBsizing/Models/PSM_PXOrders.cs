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
    
    public partial class PSM_PXOrders
    {
        public int OldRlid { get; set; }
        public string QuoteNumber { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ProjectName { get; set; }
        public string EmployeeName { get; set; }
        public string AgentName { get; set; }
        public string Comments { get; set; }
        public Nullable<decimal> TotalQuotePrice { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public Nullable<decimal> TotalOrderPrice { get; set; }
        public Nullable<decimal> Commission { get; set; }
        public string CustomerPO { get; set; }
        public Nullable<short> ProductionTime { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public bool Cancelled { get; set; }
        public string Language { get; set; }
        public bool Shipped { get; set; }
        public bool PPD { get; set; }
        public bool Collect { get; set; }
        public string oldRDRID { get; set; }
        public string ALL_SN { get; set; }
        public string ALL_MODEL { get; set; }
    }
}
