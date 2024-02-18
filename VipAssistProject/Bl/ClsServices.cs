using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Models;
namespace VipAssistProject.Bl
{
    #region IServicesServices Interface
    /// <summary>
    /// 
    /// </summary>
    public interface IServicesServices 
    {
        List<TbService> GetAllServices();
        List<VwGetServiceList> GetAllItems();
        TbService GetItemById(Guid? id);
        bool Add(TbService item);
        bool Edit(TbService item);
        bool Delete(Guid id);
        List<TbService> GetServicesWithDiscount();
    }

    #endregion
    public class ClsServices : IServicesServices
    {

        #region Methods
        /// <summary>
        /// Adding context todependency injection
        /// </summary>
        VipAssistDatabaseContext Ctx;
        public ClsServices (VipAssistDatabaseContext contxet) 
        {
            Ctx = contxet;
        }


        /// <summary>
        /// method to bring data of services and service media from database and show it
        /// </summary>
        /// <returns></returns>
        public List<TbService> GetAllServices() 
        {
            try 
            {
                
                List<TbService> LstServices = Ctx.TbServices.Include(a => a.TbServiceMedia).ToList();
                return LstServices;

            }
            catch(Exception ex) 
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }
               
            
            
        }

        /// <summary>
        /// Method to bring one of service using the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TbService GetItemById(Guid? id)
        {
            try 
            {
                
                TbService oTbService = Ctx.TbServices.Where(a => a.ServiceId == id).FirstOrDefault();
                return oTbService;
            }
            catch(Exception ex) 
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }
            
        }


        /// <summary>
        /// Method to add service to database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(TbService item)
        {
            try 
            {

                Ctx.TbServices.Add(item);
                Ctx.SaveChanges();
                return true;

            }
            catch(Exception ex) 
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return false;
            }

           
        }

        /// <summary>
        /// Method to edit service
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(TbService item)
        {
            try 
            {

                Ctx.Entry(item).State = EntityState.Modified;
                Ctx.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return false;
            }

            
        }

        /// <summary>
        /// Method to delete service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public bool Delete(Guid id)
        {
            try 
            {
               
                TbService oTbService = Ctx.TbServices.Where(a => a.ServiceId == id).FirstOrDefault();
                Ctx.TbServices.Remove(oTbService);

                Ctx.Entry(oTbService).State = EntityState.Deleted;
                Ctx.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return false;
            }
            
        }



        public List<TbService> GetServicesWithDiscount()
        {
            try 
            {
                var query = (from items in Ctx.TbServices

                             join
                             media in Ctx.TbServiceMedia
                             on items.ServiceId equals media.ServiceId

                             //where discount.EndDate <= DateTime.Now
                             select items).Include(a => a.ServiceCategory).Include(a => a.TbDiscounts).Include(a => a.TbServiceMedia);
                return query.ToList();

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }


        }

        public List<VwGetServiceList> GetAllItems()
        {
            try 
            {
                return Ctx.VwGetServiceList.ToList();
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
