using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipAssistProject.Models
{
    public class GetChats
    {
        public Guid MessagesId { get; set; }
        public string CreatedBy { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MemberId { get; set; }

        public string UpdatedBy { get; set; }
        public string ToSendId { get; set; }
    }
}
