using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class InvoicesSummary
    {
        public Guid InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string MemberId { get; set; }
        public string UserName { get; set; }
        public decimal InvoiceTotal { get; set; }
       
        
    }
}
