using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipAssistProject.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            LstServices = new List<ShoppingCartItems>();
        }
        public List<ShoppingCartItems> LstServices { get; set; }
        public decimal? Total { get; set; }
        public int Count { get; set; }
        
    }
}
