using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public class VwViewServiceMemberOrder
    {
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
        public Guid InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public string NotesAr { get; set; }
        public string NotesEn { get; set; }
        public string NotesFr { get; set; }
        public Guid InvoiceServiceId { get; set; }
       
        public int? Qty { get; set; }
        public decimal? InvoicePrice { get; set; }

        
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string NameFr { get; set; }
        public string Path { get; set; }
        
        public bool IsExternal { get; set; }
        public int PaymentArea { get; set; }
        


    }
}
