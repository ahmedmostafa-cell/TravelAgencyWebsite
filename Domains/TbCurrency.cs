using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbCurrency
    {
        public Guid CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public int? IsDefault { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
    }
}
