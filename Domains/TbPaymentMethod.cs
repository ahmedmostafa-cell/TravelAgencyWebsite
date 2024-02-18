using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbPaymentMethod
    {
        public TbPaymentMethod()
        {
            TbSalesInvoices = new HashSet<TbSalesInvoice>();
        }

        public Guid PaymentMethodId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string NameFr { get; set; }
        public string Path { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionFr { get; set; }
        public bool IsExternal { get; set; }
        public int PaymentArea { get; set; }
        public int? DisplayOrder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CurrentState { get; set; }

        public virtual ICollection<TbSalesInvoice> TbSalesInvoices { get; set; }
    }
}
