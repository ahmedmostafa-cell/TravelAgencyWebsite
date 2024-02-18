using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipAssistProject.Models
{
    public class SliderImagesPageModel
    {
        #region Declaration
        public IEnumerable<TbSliderImage> LstSliderImages { get; set; }

        public TbSliderImage SliderImage { get; set; }
        #endregion
    }
}
