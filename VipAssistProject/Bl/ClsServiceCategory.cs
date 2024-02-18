using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Models;
namespace VipAssistProject.Bl
{
    #region IServiceCategoriesServices Interface
    public interface IServiceCategoriesServices
    {
        List<TbServiceCategory> GetAllServiceCategories();
       
    }
    #endregion

    
    public class ClsServiceCategory : IServiceCategoriesServices
    {

        #region Methods

        /// <summary>
        /// Adding Context to depenecy injection
        /// </summary>
        VipAssistDatabaseContext Ctx;
        public ClsServiceCategory(VipAssistDatabaseContext contxet)
        {
            Ctx = contxet;
        }

        /// <summary>
        /// method to show All services categories
        /// </summary>
        /// <returns></returns>
        public List<TbServiceCategory> GetAllServiceCategories() 
        {
            try 
            {
                
                List<TbServiceCategory> LstServiceCategories = Ctx.TbServiceCategories.Where(a => a.CurrentState == 1).ToList();
                return LstServiceCategories;
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }


        }

        #endregion
    }
}
