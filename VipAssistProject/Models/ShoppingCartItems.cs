using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipAssistProject.Models
{
    public class ShoppingCartItems
    {
        public Guid ServiceId { get; set; }
        public string TitleEn { get; set; }

        public string TitleFr { get; set; }
        public string Path { get; set; }
        public decimal? Price { get; set; }
        
        
        public int Qty { get; set; }
        public decimal? Total { get; set; }
        public string? CarName { get; set; }

        public string? FlightStatus { get; set; }

        public string? FlightDate { get; set; }

        public string? FlightName { get; set; }

        public int? PersonQty { get; set; }

        public int? InfantQty { get; set; }

        public int? BagQty { get; set; }
        
    }
}
