using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipAssistProject.Models
{
    public class ServiceMediaPageModel
    {
        #region Declaration
        public IEnumerable<TbServiceMedium> LstServicesMedia { get; set; }
        
       public TbServiceMedium ServiceMedia { get; set; }
        #endregion
    }
}
