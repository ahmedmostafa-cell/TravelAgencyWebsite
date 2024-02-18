using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipAssistProject.Models
{
    public class SalesInvoicePageModel
    {
        public IEnumerable<TbSalesInvoice> LstSalesInvoices { get; set; }
        public IEnumerable<InvoicesSummary> LstInvoicesSummary { get; set; }

        public IEnumerable<InvoiceDetails> LstInvoiceDetails { get; set; }

        public IEnumerable<InvoiceDetailsNew> LstInvoiceDetailsNew { get; set; }
        public IEnumerable<TbSalesInvoiceService> LstTbSalesInvoiceService { get; set; }

        public IEnumerable<VwLoyalityPoints> LstLoyalityPoints { get; set; }
        public TbSalesInvoice SalesInvoice { get; set; }
        public TbSalesInvoiceService SalesInvoiceService { get; set; }
    }
}
