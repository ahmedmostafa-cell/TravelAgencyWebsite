using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbSalesInvoice
    {
        public TbSalesInvoice()
        {
            TbSalesInvoiceServices = new HashSet<TbSalesInvoiceService>();
        }

        public Guid InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string MemberId { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public string NotesAr { get; set; }
        public string NotesEn { get; set; }
        public string NotesFr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual TbPaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<TbSalesInvoiceService> TbSalesInvoiceServices { get; set; }
    }
}
