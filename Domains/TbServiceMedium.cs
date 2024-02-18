using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbServiceMedium
    {
        public Guid ServiceMediaId { get; set; }
        public Guid? ServiceId { get; set; }
        public int? MediaType { get; set; }
        public string Path { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string TitleFr { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionFr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CurrentState { get; set; }
        public bool IsDefault { get; set; }
        public bool IsPageHeader { get; set; }

        public virtual TbService Service { get; set; }
    }
}
