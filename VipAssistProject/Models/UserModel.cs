using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domains;
namespace VipAssistProject.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public IEnumerable<TbWishList> LstWishList { get; set; }
        public ShoppingCart cart { get; set; }
        public IEnumerable<TbService> LstServices { get; set; }

        public IEnumerable<VwGetServiceList> LstServicesWithMedia { get; set; }


        public IEnumerable<TbServiceMedium> LstServicesWithMediaa { get; set; }
        public TbService Service { get; set; }

        public IEnumerable<TbSliderImage> LstSliderImages { get; set; }

        public TbSliderImage SliderImage { get; set; }

        public ShoppingCart Cart { get; set; }

        public UserModel user { get; set; }



    }
}
