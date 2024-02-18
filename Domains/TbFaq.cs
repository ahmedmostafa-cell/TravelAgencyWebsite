using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbFaq
    {
        public Guid Faqid { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
    }
}
