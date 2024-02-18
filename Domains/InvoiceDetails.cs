using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class InvoiceDetails
    {
        public Guid InvoiceId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string TitleEn { get; set; }
        public int Qty { get; set; }
        public decimal InvoicePrice { get; set; }
    }
}
