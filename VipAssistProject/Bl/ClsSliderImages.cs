using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Models;
namespace VipAssistProject.Bl
{

    #region ISliderImagesServices Interface
    public interface ISliderImagesServices
    {
        List<TbSliderImage> GetAllSliderImages();
        TbSliderImage GetItemById(Guid? id);
        bool Add(TbSliderImage item);
        bool Edit(TbSliderImage item);
        bool Delete(Guid id);
    }

    #endregion
    public class ClsSliderImages : ISliderImagesServices
    {

        #region Methods

        /// <summary>
        ///  Adding context todependency injection
        /// </summary>
        VipAssistDatabaseContext Ctx;
        public ClsSliderImages(VipAssistDatabaseContext contxet)
        {
            Ctx = contxet;
        }


        /// <summary>
        /// method to bring data of sliders from database and show it
        /// </summary>
        /// <returns></returns>
        public List<TbSliderImage> GetAllSliderImages()
        {
            try
            {

                List<TbSliderImage> LstSliderImages = Ctx.TbSliderImages.ToList();
                return LstSliderImages;

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }



        }


        /// <summary>
        /// Method to bring one of slider images using the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TbSliderImage GetItemById(Guid? id)
        {
            try
            {

                TbSliderImage oTbSliderImage = Ctx.TbSliderImages.Where(a=> a.ImageId== id).FirstOrDefault();
                return oTbSliderImage;
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }

        }


        /// <summary>
        /// Method to add slider image
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(TbSliderImage item)
        {
            try
            {

                Ctx.TbSliderImages.Add(item);
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
        /// Method to edit slider image
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(TbSliderImage item)
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
        /// Method to add delete image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            try
            {

                TbSliderImage oTbSliderImage = Ctx.TbSliderImages.Where(a => a.ImageId == id).FirstOrDefault();
                Ctx.TbSliderImages.Remove(oTbSliderImage);
                Ctx.Entry(oTbSliderImage).State = EntityState.Deleted;
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

        #endregion
    }
}
