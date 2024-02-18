using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class InvoiceDetailsNew
    {
        public Guid InvoiceId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string TitleEn { get; set; }
        public int Qty { get; set; }
        public decimal InvoicePrice { get; set; }

        public string UserName { get; set; }

        public string NotesAr { get; set; }


        public string NotesEn { get; set; }


        public string NotesFr { get; set; }


        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string CarName { get; set; }
        

    }
}
