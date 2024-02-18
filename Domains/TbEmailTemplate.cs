using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbEmailTemplate
    {
        public Guid EmailTemplateId { get; set; }
        public string Services { get; set; }
        public string Categories { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public string Files { get; set; }
        public int? LeadType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
    }
}
