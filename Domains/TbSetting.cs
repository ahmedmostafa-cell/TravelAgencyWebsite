using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbSetting
    {
        public Guid SettingId { get; set; }
        public string SiteNameAr { get; set; }
        public string SiteNameEn { get; set; }
        public string SiteNameFr { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string LocationUrl { get; set; }
        public string Phone { get; set; }
        public string WhatsNumber { get; set; }
        public string Logo { get; set; }
        public string MainImage { get; set; }
        public string MainVideo { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string GooglePlus { get; set; }
        public string SoundCloud { get; set; }
        public string MetaTags { get; set; }
        public string MetaDescription { get; set; }
        public int? CurrentState { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string GoogleAnalytics { get; set; }
        public string FacebookPixel { get; set; }
        public string TwitterPixel { get; set; }
    }
}
