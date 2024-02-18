using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Models;
using VipAssistProject.Bl;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace VipAssistProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {

        #region Declaration
        ISliderImagesServices SliderImagesService;
        

        public SliderController(ISliderImagesServices sliderImagesService)
        {
            SliderImagesService = sliderImagesService;
            


        }
        #endregion


        #region Methods

        /// <summary>
        /// method to show slider images
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()


        {
           try 
            {
                List<TbSliderImage> LstSliderImages = SliderImagesService.GetAllSliderImages();
                if (HttpContext.Session.GetString("message") != null)
                {

                    ViewBag.message = HttpContext.Session.GetString("message");
                }
                else
                {
                    ViewBag.message = null;
                }

                SliderImagesPageModel oSliderImagesPageModel = new SliderImagesPageModel();
                oSliderImagesPageModel.LstSliderImages = LstSliderImages;



                return View(oSliderImagesPageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                RedirectToAction("Error", "Home", ex.Message);
                return null;

            }


        }

        /// <summary>
        /// Method to add or edit Slider image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Form(Guid? id)
        {

           
            try 
            {
                if (id != null)
                {

                    TbSliderImage oTbSliderImage = SliderImagesService.GetItemById(id);

                    return View(oTbSliderImage);

                }
                else
                {

                    return View();
                }
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                RedirectToAction("Error", "Home", ex.Message);
                return null;

            }



        }

        /// <summary>
        /// Method to save the add or the edit of Slider
        /// </summary>
        /// <param name="ImageId"></param>
        /// <param name="ImageTextEn"></param>
        /// <param name="ImageTextFr"></param>
        /// <param name="ImageTitleEn"></param>
        /// <param name="ImageTitleFr"></param>
        /// <param name="ImageOrder"></param>
        /// <param name="CurrentState"></param>
        /// <param name="form"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save(Guid ImageId, string ImageTextEn , string ImageTextFr , string ImageTitleEn, string ImageTitleFr, int? ImageOrder, int? CurrentState , IFormCollection form, List<IFormFile> files)
        {
            try 
            {
                TbSliderImage item = new TbSliderImage();
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        item.ImagePath = ImageName;
                    }
                }

                item.ImageId = ImageId;



                item.ImageTitleEn = ImageTitleEn;
                item.ImageTitleFr = ImageTitleFr;
                item.ImageTextEn = ImageTextEn;
                item.ImageTextFr = ImageTextFr;
                item.CurrentState = CurrentState;
                item.ImageOrder = ImageOrder;


                if (item.ImageId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {



                    SliderImagesService.Add(item);
                    HttpContext.Session.SetString("message", "success");

                    return RedirectToAction("Index");

                }
                else
                {

                    SliderImagesService.Edit(item);
                    HttpContext.Session.SetString("message", "success");
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                RedirectToAction("Error", "Home", ex.Message);
                return null;

            }





        }

        /// <summary>
        /// method to delete Slider Image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(Guid id)
        {
            try 
            {
                bool result = SliderImagesService.Delete(id);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                RedirectToAction("Error", "Home", ex.Message);
                return null;

            }

        }

        #endregion
    }
}
