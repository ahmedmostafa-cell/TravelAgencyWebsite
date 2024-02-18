using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Bl;
using VipAssistProject.Models;
namespace VipAssistProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServicesMedia : Controller
    {

        #region Declaration
        IServicesServices ServicesService;
        IServiceCategoriesServices ServiceCategoriesService;
        IServiceMediasServices ServiceMediaService;
        /// <summary>
        /// Adding Interface to Dependency Injection
        /// </summary>
        /// <param name="servicesService"></param>
        /// <param name="serviceCategoriesService"></param>
        /// <param name="serviceMediaService"></param>
        public ServicesMedia(IServicesServices servicesService, IServiceCategoriesServices serviceCategoriesService , IServiceMediasServices serviceMediaService)
        {
            ServicesService = servicesService;
            ServiceCategoriesService = serviceCategoriesService;
            ServiceMediaService = serviceMediaService;


        }

        #endregion


        #region Methods

        /// <summary>
        /// Make static data for choosing media type of service
        /// </summary>
        /// <returns></returns>
        private IList<SelectListItem> CreateLstMediaTypes()
        {
            IList<SelectListItem> lstMediaTypes = new List<SelectListItem>
            {
                new SelectListItem{Text = "Image", Value = "1"},
                new SelectListItem{Text = "Video", Value = "2"}
            };
            return lstMediaTypes;
        }


        /// <summary>
        /// method to show page of media of services
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        
        
        {
            try 
            {
                ViewBag.MediaType = new SelectList(CreateLstMediaTypes(), "value", "text", 1);
                ViewBag.MediaTypeS = new List<string>() { "Image", "Video" };

                List<TbServiceMedium> LstServices = ServiceMediaService.GetAllServices();
                if (HttpContext.Session.GetString("message") != null)
                {

                    ViewBag.message = HttpContext.Session.GetString("message");
                }
                else
                {
                    ViewBag.message = null;
                }

                ServiceMediaPageModel oServiceMediaPageModel = new ServiceMediaPageModel();
                oServiceMediaPageModel.LstServicesMedia = LstServices;

                ViewBag.Services = ServicesService.GetAllServices();

                return View(oServiceMediaPageModel);
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
        /// Method to add or edit Service media
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Form(Guid? id)
        {
            try 
            {
                ViewBag.Categories = ServiceCategoriesService.GetAllServiceCategories();
                ViewBag.MediaType = new SelectList(CreateLstMediaTypes(), "value", "text", 1);
                ViewBag.MediaTypeS = new List<string>() { "Image", "Video" };

                ViewBag.Services = ServicesService.GetAllServices();

                if (id != null)
                {

                    TbServiceMedium oTbServiceMedium = ServiceMediaService.GetItemById(id);

                    return View(oTbServiceMedium);

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
        /// Method to save the add or the edit of service media
        /// </summary>
        /// <param name="ServiceMediaId"></param>
        /// <param name="TitleEn"></param>
        /// <param name="TitleFr"></param>
        /// <param name="ServiceId"></param>
        /// <param name="form"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save(Guid ServiceMediaId , string TitleEn, string TitleFr, Guid ServiceId , IFormCollection form , List<IFormFile> files)
        {
            try 
            {
                TbServiceMedium item = new TbServiceMedium();
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
                        item.Path = ImageName;
                    }
                }
                item.ServiceId = ServiceId;
                item.ServiceMediaId = ServiceMediaId;
                string strDDLValue = form["MediaType"].ToString();
                if (strDDLValue == "Image")
                {
                    item.MediaType = 1;
                }
                else
                {
                    item.MediaType = 2;
                }

                item.TitleEn = TitleEn;
                item.TitleFr = TitleFr;


                if (item.ServiceMediaId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {



                    ServiceMediaService.Add(item);
                    HttpContext.Session.SetString("message", "success");

                    return RedirectToAction("Index");

                }
                else
                {

                    ServiceMediaService.Edit(item);
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
        /// Method to save the add or the editof service media
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(Guid id)
        {
            try 
            {
                bool result = ServiceMediaService.Delete(id);
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
