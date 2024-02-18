using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbSliderImage
    {
        public Guid ImageId { get; set; }
        public string ImagePath { get; set; }
        public string ImageTitleAr { get; set; }
        public string ImageTitleEn { get; set; }
        public string ImageTitleFr { get; set; }
        public string ImageTextAr { get; set; }
        public string ImageTextEn { get; set; }
        public string ImageTextFr { get; set; }
        public int? ImageOrder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
    }
}
