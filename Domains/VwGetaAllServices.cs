using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class VwGetaAllServices
    {
        public Guid ServiceId { get; set; }

        
        public Guid? ServiceCategoryId { get; set; }
        
        public string TitleAr { get; set; }
        
        public string TitleEn { get; set; }
        
        public string TitleFr { get; set; }
        public string ShortDescriptionAr { get; set; }
        public string ShortDescriptionEn { get; set; }
        public string ShortDescriptionFr { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionFr { get; set; }
        
        public decimal? Price { get; set; }
        public decimal? BookingPrice { get; set; }
        public string PaymentLink { get; set; }
        public bool? ShowInHomePage { get; set; }
        public string ServiceCode { get; set; }
        public string MetaTags { get; set; }
        public string MetaDescription { get; set; }
        public int? ReferToLead { get; set; }
        public int? DisplayOrder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
        public Guid? PlayerId { get; set; }

       
    }
}
