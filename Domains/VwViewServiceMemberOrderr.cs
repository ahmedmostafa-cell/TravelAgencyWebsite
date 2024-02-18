using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class VwViewServiceMemberOrderr
    {
        public Guid InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string MemberId { get; set; }
        public Guid? PaymentMethodId { get; set; }


        public Guid InvoiceServiceId { get; set; }
        public Guid? ServiceId { get; set; }
        


        public int? Qty { get; set; }
        public decimal? InvoicePrice { get; set; }
        
        public Guid? ServiceCategoryId { get; set; }
       
        public string TitleAr { get; set; }
        
        public string TitleEn { get; set; }
       
        public string TitleFr { get; set; }
        public string Email { get; set; }
        

    }
}
