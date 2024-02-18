using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Models;
namespace VipAssistProject.Bl
{

    #region IServiceMediasServices Interface
    public interface IServiceMediasServices
    {
        List<TbServiceMedium> GetAllServices();
        TbServiceMedium GetItemById(Guid? id);
        bool Add(TbServiceMedium item);
        bool Edit(TbServiceMedium item);
        bool Delete(Guid id);
        List<ApplicationUser> LstUsersData();
    }

    #endregion
    public class ClsServicesMedia : IServiceMediasServices
    {

        #region Methods

        /// <summary>
        /// Adding context todependency injection
        /// </summary>
        VipAssistDatabaseContext Ctx;
        public ClsServicesMedia(VipAssistDatabaseContext contxet)
        {
            Ctx = contxet;
        }

        /// <summary>
        ///  method to bring data of services media from table of service media and show it
        /// </summary>
        /// <returns></returns>
        public List<TbServiceMedium> GetAllServices()
        {
            try
            {
                
                List<TbServiceMedium> LstServices = Ctx.TbServiceMedia.Include(a => a.Service).ToList();
                return LstServices;

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }



        }


        /// <summary>
        /// Method to bring one of service media data using the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TbServiceMedium GetItemById(Guid? id)
        {
            try
            {
                
                TbServiceMedium oTbServiceMedium = Ctx.TbServiceMedia.Where(a => a.ServiceMediaId == id).FirstOrDefault();
                return oTbServiceMedium;
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }
        }



        /// <summary>
        /// Method to add service media
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(TbServiceMedium item)
        {
            try
            {

                Ctx.TbServiceMedia.Add(item);
                Ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return false;
            }


        }



        /// <summary>
        /// Method to edit service media
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public bool Edit(TbServiceMedium item)
        {
            try
            {

                Ctx.Entry(item).State = EntityState.Modified;
                Ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return false;
            }


        }



        /// <summary>
        /// Method to delete service media
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            try
            {
                
                TbServiceMedium oTbServiceMedium = Ctx.TbServiceMedia.Where(a => a.ServiceMediaId == id).FirstOrDefault();
                Ctx.TbServiceMedia.Remove(oTbServiceMedium);
                Ctx.Entry(oTbServiceMedium).State = EntityState.Deleted;
                Ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return false;
            }

        }


        public List<ApplicationUser> LstUsersData()
        {
            try
            {

                List<ApplicationUser> Lst = Ctx.Users.ToList();

                return Lst;

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
