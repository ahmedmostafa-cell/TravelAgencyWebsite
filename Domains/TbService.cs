using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VipAssistProject.Models
{
    public partial class TbService
    {
        public TbService()
        {
            TbCarts = new HashSet<TbCart>();
            TbDiscounts = new HashSet<TbDiscount>();
            TbReviews = new HashSet<TbReview>();
            TbSalesInvoiceServices = new HashSet<TbSalesInvoiceService>();
            TbServiceFeatures = new HashSet<TbServiceFeature>();
            TbServiceMedia = new HashSet<TbServiceMedium>();
            TbWishLists = new HashSet<TbWishList>();
        }

        public Guid ServiceId { get; set; }

        [Required(ErrorMessage = "Please Select Service Category")]
        public Guid? ServiceCategoryId { get; set; }
        [Required(ErrorMessage = "Please Enter Arabic Name of Service")]
        public string TitleAr { get; set; }
        [Required(ErrorMessage = "Please Enter English Name of Service")]
        public string TitleEn { get; set; }
        [Required(ErrorMessage = "Please Enter French Name of Service")]
        public string TitleFr { get; set; }
        public string ShortDescriptionAr { get; set; }
        public string ShortDescriptionEn { get; set; }
        public string ShortDescriptionFr { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionFr { get; set; }
        [Required(ErrorMessage = "Please Enter Service Price")]
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

        public virtual TbServiceCategory ServiceCategory { get; set; }
        public virtual ICollection<TbCart> TbCarts { get; set; }
        public virtual ICollection<TbDiscount> TbDiscounts { get; set; }
        public virtual ICollection<TbReview> TbReviews { get; set; }
        public virtual ICollection<TbSalesInvoiceService> TbSalesInvoiceServices { get; set; }
        public virtual ICollection<TbServiceFeature> TbServiceFeatures { get; set; }
        public virtual ICollection<TbServiceMedium> TbServiceMedia { get; set; }
        public virtual ICollection<TbWishList> TbWishLists { get; set; }
    }
}
