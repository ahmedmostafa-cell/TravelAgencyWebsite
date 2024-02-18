using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbSalesInvoiceService
    {
        public Guid InvoiceServiceId { get; set; }
        public Guid? ServiceId { get; set; }
        public Guid? InvoiceId { get; set; }
        public int? Qty { get; set; }
        public decimal? InvoicePrice { get; set; }
        public string NotesAr { get; set; }
        public string NotesEn { get; set; }
        public string NotesFr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? LoyalityPoints { get; set; }

        public string CarName { get; set; }
        

        public virtual TbSalesInvoice Invoice { get; set; }
        public virtual TbService Service { get; set; }
    }
}
