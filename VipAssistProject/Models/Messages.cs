using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VipAssistProject.Models
{
    public class Messages
    {
        public int MessagesId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime When { get; set; }
        public string UserId { get; set; }
        public string ToSendId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
       

    }
}
