using System;
using System.Collections.Generic;



namespace VipAssistProject.Models
{
    public partial class TbErrorLog
    {
        public Guid LogId { get; set; }
        public string ErrorMessage { get; set; }
        public string InnerExceptionMessage { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string StackTrace { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
