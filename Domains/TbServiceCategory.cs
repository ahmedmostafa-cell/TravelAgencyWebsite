using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbServiceCategory
    {
        public TbServiceCategory()
        {
            TbServices = new HashSet<TbService>();
        }

        public Guid ServiceCategoryId { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string TitleFr { get; set; }
        public int? CategoryCode { get; set; }
        public int? ParentCategoryCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CurrentState { get; set; }

        public virtual ICollection<TbService> TbServices { get; set; }
    }
}
