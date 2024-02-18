using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbVideo
    {
        public Guid VideoId { get; set; }
        public Guid? ModuleId { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string TitleFr { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionFr { get; set; }
        public int? VideoOrder { get; set; }
        public string Path { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
        public int? IsFree { get; set; }
    }
}
