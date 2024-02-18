using System;
using System.Collections.Generic;


namespace VipAssistProject.Models
{
    public partial class TbServiceFeature
    {
        public Guid FeatureId { get; set; }
        public Guid? ServiceId { get; set; }
        public string FeatureTextAr { get; set; }
        public string FeatureTextEn { get; set; }
        public string FeatureTextFr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CurrentState { get; set; }

        public virtual TbService Service { get; set; }
    }
}
