using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbWishList
    {
        public Guid WishListId { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? MemberId { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string TitleFr { get; set; }
        public decimal? Price { get; set; }
        public decimal? BookingPrice { get; set; }
        public double? DiscountPercent { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? NewSalePrice { get; set; }
        public DateTime? StartDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }

        public virtual TbService Service { get; set; }
    }
}
