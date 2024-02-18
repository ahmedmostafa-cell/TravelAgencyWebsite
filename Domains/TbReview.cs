using System;
using System.Collections.Generic;


namespace VipAssistProject.Models
{
    public partial class TbReview
    {
        public Guid ReviewId { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? MemberId { get; set; }
        public string ReviewText { get; set; }
        public double? Rating { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual TbService Service { get; set; }
    }
}
