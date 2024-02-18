using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbNewsLetter
    {
        public Guid NewsLetterId { get; set; }
        public string Email { get; set; }
        public int? CurrentState { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
