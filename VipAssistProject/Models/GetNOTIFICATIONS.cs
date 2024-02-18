using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipAssistProject.Models
{
    public class GetNOTIFICATIONS
    {
        public int PostId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Id { get; set; }

        public string UserNamePost { get; set; }
        public string UserNameComment { get; set; }

    }
}
