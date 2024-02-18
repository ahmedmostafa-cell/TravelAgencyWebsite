using System;
using System.Collections.Generic;


namespace VipAssistProject.Models
{
    public partial class TbMessage
    {
        public Guid MessagesId { get; set; }
        public Guid? MemberId { get; set; }
        public string MessageText { get; set; }
        public Guid? ToSendId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
    }
}
