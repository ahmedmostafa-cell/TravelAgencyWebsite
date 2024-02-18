using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbDiscount
    {
        public Guid DiscountId { get; set; }
        public Guid? ServiceId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? DiscountValue { get; set; }
        public bool? IsPercentage { get; set; }
        public bool? IsPermanent { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CurrentState { get; set; }

        public virtual TbService Service { get; set; }
    }
}
