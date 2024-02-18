using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class HomeController : Controller
    {
        #region Declaration 

        IServicesServices ServicesService;
        IServiceCategoriesServices ServiceCategoriesService;
        VipAssistDatabaseContext Ctx;
        /// <summary>
        /// Adding Interface to Dependency Injection
        /// </summary>
        /// <param name="servicesService"></param>
        /// <param name="serviceCategoriesService"></param>

        public HomeController(VipAssistDatabaseContext ctx ,IServicesServices servicesService , IServiceCategoriesServices serviceCategoriesService)
        {
            ServicesService = servicesService;
            ServiceCategoriesService = serviceCategoriesService;

            Ctx = ctx;
        }
        #endregion


        #region Mthods

        /// <summary>
        /// Home Page of Admin Panel
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Toast()
        {

            return View();
        }



       

        /// <summary>
        /// Services List Show
        /// </summary>
        /// <returns></returns>
        public IActionResult Services()
        {
            try 
            {
                List<TbService> LstServices = ServicesService.GetAllServices();
                if (HttpContext.Session.GetString("message") != null)
                {

                    ViewBag.message = HttpContext.Session.GetString("message");
                }
                else
                {
                    ViewBag.message = null;
                }



                return View(LstServices);

            }
            catch(Exception ex) 
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                
                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }
            
            
        }

        /// <summary>
        /// Method to add or edit Service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Form(Guid? id)
        {
            try 
            {
                ViewBag.Categories = ServiceCategoriesService.GetAllServiceCategories();

                if (id != null)
                {

                    TbService oTbService = ServicesService.GetItemById(id);

                    return View(oTbService);

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
        /// Method to save the add or the edit of service
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save(TbService item)
        {

            try 
            {
                if (item.ServiceId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {



                    ServicesService.Add(item);
                    HttpContext.Session.SetString("message", "success");

                    return RedirectToAction("Services");

                }
                else
                {

                    ServicesService.Edit(item);
                    HttpContext.Session.SetString("message", "success");
                    return RedirectToAction("Services");
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
        /// method to delete service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(Guid id)
        {
            try 
            {
                bool result = ServicesService.Delete(id);
                if (result)
                {
                    return RedirectToAction("Services");
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



        public IActionResult ContactUsDisplay()
        {
            try
            {
                List<TbArticle> LstMessages = Ctx.TbArticles.OrderByDescending(A=> A.CreatedDate.Value.Month < DateTime.Now.Month).ThenByDescending(A => A.CreatedDate.Value.Date < DateTime.Now.Date).ToList();
                



                return View(LstMessages);

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
