using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbLanguage
    {
        public Guid LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string IsDefault { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CurrentState { get; set; }
    }
}
