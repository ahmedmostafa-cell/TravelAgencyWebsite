using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipAssistProject.Bl
{
    [Serializable]
    public class BlException : Exception
    {
        public string ErrorMessage { get; set; }
        public string UserErrorMessage { get; set; }
        public BlException(Exception ex) 
        {
            ErrorMessage = ex.Message;
            UserErrorMessage = "error in business layer please try again";
            if (ex.InnerException is InvalidOperationException) 
            {
                UserErrorMessage = "error in operation system please try again";
            }
            else if(ex.InnerException is OutOfMemoryException) 
            {
                UserErrorMessage = "overload on server please try again";
            }

        }
        public BlException(string name)
            :base(string.Format("invalid student name : {0}" , name))
        {

        }
    }
}
