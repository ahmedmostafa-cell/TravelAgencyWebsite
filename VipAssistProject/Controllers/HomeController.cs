using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Models;
using VipAssistProject.Bl;

using Domains.Resources;
using System.Globalization;
using VipAssistProject.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using EmailService;
using MimeKit;

namespace VipAssistProject.Controllers
{
    public class HomeController : Controller
    {

        #region Declarartion
        VipAssistDatabaseContext Ctx;
        ISliderImagesServices SliderImagesServices;
        IServiceMediasServices ServiceMediasServices;
        IGetChat Eight;
        private readonly UserManager<ApplicationUser> UserManager;
        /// <summary>
        /// Adding Interface to Dependency Injection
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="sliderImagesServices"></param>
        /// <param name="serviceMediasServices"></param>

        public HomeController(UserManager<ApplicationUser> userManager , IGetChat eight  , VipAssistDatabaseContext ctx , ISliderImagesServices sliderImagesServices , IServiceMediasServices serviceMediasServices)
        {
            Ctx = ctx;
            SliderImagesServices = sliderImagesServices;
            ServiceMediasServices = serviceMediasServices;
            Eight = eight;
            UserManager = userManager;
        }

        #endregion

        #region Method

        /// <summary>
        /// Method to show all data in the index page
        /// </summary>
        /// <returns></returns>
        /// 


        public IActionResult AboutUs(string id)
        {
            try
            {
                string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
                string SenderId = "";
                if (id != null)
                {
                    SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
                }
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
               
                string strCurrentUserId = User.Identity.Name;
                if (strCurrentUserId != null)
                {
                    if (id == null)
                    {
                        ViewBag.Tosend = idd;
                    }
                    else
                    {
                        ViewBag.Tosend = SenderId;
                    }

                    var currentUser = UserManager.GetUserAsync(User);
                    if (User.Identity.IsAuthenticated)
                    {
                        ViewBag.CurrentUserName = currentUser.Result.UserName;
                    }
                    if (id == null)
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, idd);
                    }
                    else
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, SenderId);
                    }
                }
               
            
                return View(oHomePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }
        }

        public async Task<IActionResult> Index(string id)
        {
            try 
            {
                string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
                string SenderId = "";
                if (id != null)
                {
                    SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
                }
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                string strCurrentUserId = User.Identity.Name;
                if (strCurrentUserId != null)
                {
                    if (id == null)
                    {
                        ViewBag.Tosend = idd;
                    }
                    else
                    {
                        ViewBag.Tosend = SenderId;
                    }

                    var currentUser = await UserManager.GetUserAsync(User);
                    if (User.Identity.IsAuthenticated)
                    {
                        ViewBag.CurrentUserName = currentUser.UserName;
                    }
                    if (id == null)
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, idd);
                    }
                    else
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, SenderId);
                    }
                }

                return View(oHomePageModel);
            }    
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }

            
        }

        public IActionResult AirportBooking( string id)
        {
            try
            {
                ViewBag.Airport = id;
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                return View(oHomePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }


        }

        #region Test Index Pages
        public IActionResult Index1()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult Index4()
        {
            return View();
        }
        public IActionResult Index5()
        {
            return View();
        }
        public IActionResult Index6()
        {
            return View();
        }
        public IActionResult Error(string UserErrorMessage)
        {
            return View();
        }

        public IActionResult ContactUs(string UserErrorMessage , string id)
        {
            try
            {
                string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
                string SenderId = "";
                if (id != null)
                {
                    SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
                }
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                oHomePageModel.Message = new TbArticle();
                string strCurrentUserId = User.Identity.Name;
                if (strCurrentUserId != null)
                {
                    if (id == null)
                    {
                        ViewBag.Tosend = idd;
                    }
                    else
                    {
                        ViewBag.Tosend = SenderId;
                    }

                    var currentUser = UserManager.GetUserAsync(User);
                    if (User.Identity.IsAuthenticated)
                    {
                        ViewBag.CurrentUserName = currentUser.Result.UserName;
                    }
                    if (id == null)
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, idd);
                    }
                    else
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, SenderId);
                    }
                }
                return View(oHomePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }
        }
        public IActionResult RecieveMessage(TbArticle Message)
        {
            
            try
            {
                Ctx.TbArticles.Add(Message);
                Ctx.SaveChanges();
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                return View("Index", oHomePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }
        }

       



        public IActionResult Locations(string id)
        {
            try
            {
                string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
                string SenderId = "";
                if (id != null)
                {
                    SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
                }
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                string strCurrentUserId = User.Identity.Name;
                if (strCurrentUserId != null)
                {
                    if (id == null)
                    {
                        ViewBag.Tosend = idd;
                    }
                    else
                    {
                        ViewBag.Tosend = SenderId;
                    }

                    var currentUser = UserManager.GetUserAsync(User);
                    if (User.Identity.IsAuthenticated)
                    {
                        ViewBag.CurrentUserName = currentUser.Result.UserName;
                    }
                    if (id == null)
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, idd);
                    }
                    else
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, SenderId);
                    }
                }
                return View(oHomePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }
        }

        public IActionResult FAQ(string UserErrorMessage, string id)
        {
            try
            {
                string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
                string SenderId = "";
                if (id != null)
                {
                    SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
                }
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                string strCurrentUserId = User.Identity.Name;
                if (strCurrentUserId != null)
                {
                    if (id == null)
                    {
                        ViewBag.Tosend = idd;
                    }
                    else
                    {
                        ViewBag.Tosend = SenderId;
                    }

                    var currentUser = UserManager.GetUserAsync(User);
                    if (User.Identity.IsAuthenticated)
                    {
                        ViewBag.CurrentUserName = currentUser.Result.UserName;
                    }
                    if (id == null)
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, idd);
                    }
                    else
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, SenderId);
                    }
                }
                return View(oHomePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }
        }

        public IActionResult ChangeLanguage(string lang, string url)
        {
            if (lang == "en")
            {
                ResWebsite.Culture = ResDomains.Culture = new CultureInfo("en");
            }
            else
            {
                ResWebsite.Culture = ResDomains.Culture = new CultureInfo("ar");
            }
            return Redirect(url);
        }




        public IActionResult GetNotification()
        {

            string strCurrentUserId = User.Identity.Name;
            string id = "1045d9c2-86ea-4fd1-b283-7f5a16ad2eff";
            
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
            oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, id);
            var notification = oHomePageModel.LstChats;
            return Ok(new { UserNotification = notification, Count = notification.ToList().Count });
        }
       
        public  IActionResult NewChat(string id)
        {
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
          
            return View(oHomePageModel);
        }
        public IActionResult NewChat2(string id)
        {
            string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
            string SenderId = "";
            if (id != null)
            {
                SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
            }
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
            

            return View(oHomePageModel);
        }








        public IActionResult NewChat3(string id)
        {
            string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
            string SenderId = "";
            if (id != null)
            {
                SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
            }
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
            string strCurrentUserId = User.Identity.Name;

            

            return View(oHomePageModel);
        }











        public IActionResult NewChat4(string id)
        {
            string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
            string SenderId = "";
            if (id != null)
            {
                SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
            }
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
            string strCurrentUserId = User.Identity.Name;
            if (id == null)
            {
                ViewBag.Tosend = idd;
            }
            else
            {
                ViewBag.Tosend = SenderId;
            }
            
            var currentUser = UserManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.Result.UserName;
            }
            if (id == null)
            {
                oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, idd);
            }
            else
            {
                oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, SenderId);
            }

            return View(oHomePageModel);
        }





        public IActionResult NewChat5(string id)
        {
            string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
            string SenderId = "";
            if (id != null)
            {
                SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
            }
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
            string strCurrentUserId = User.Identity.Name;
            if (id == null)
            {
                ViewBag.Tosend = idd;
            }
            else
            {
                ViewBag.Tosend = SenderId;
            }

            

            return View(oHomePageModel);
        }


        public IActionResult NewChat6(string id)
        {
            string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
            string SenderId = "";
            if (id != null)
            {
                SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
            }
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
            string strCurrentUserId = User.Identity.Name;
            if (id == null)
            {
                ViewBag.Tosend = idd;
            }
            else
            {
                ViewBag.Tosend = SenderId;
            }

            var currentUser = UserManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.Result.UserName;
            }
           






            return View(oHomePageModel);
        }




        [Authorize]
        public IActionResult NewChat7(string id)
        {
            string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
            string SenderId = "";
            if (id != null)
            {
                SenderId = Ctx.Users.Where(a => a.Email == id).FirstOrDefault().Id;
            }
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
            string strCurrentUserId = User.Identity.Name;
            if(strCurrentUserId != null) 
            {
                if (id == null)
                {
                    ViewBag.Tosend = idd;
                }
                else
                {
                    ViewBag.Tosend = SenderId;
                }

                var currentUser = UserManager.GetUserAsync(User);
                if (User.Identity.IsAuthenticated)
                {
                    ViewBag.CurrentUserName = currentUser.Result.UserName;
                }
                if (id == null)
                {
                    oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, idd);
                }
                else
                {
                    oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, SenderId);
                }










                return View(oHomePageModel);

            }
            else 
            {









                return Redirect("/Home/Index/");
            }
            
        }










         





public async Task<IActionResult> CheckNotifications()
        {
            string id = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
            string strCurrentUserId = User.Identity.Name;
            ViewBag.Tosend = id;
            var currentUser = await UserManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }

            oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, id);
            //var messages = await ctx.Messages.ToListAsync();
            //var messages = await ctx.Messages.Where(a => a.UserName == currentUser.UserName && a.ToSendId == id).ToListAsync();
            return View(oHomePageModel);
        }

        
        public async Task<IActionResult> Createe(TbMessage message, string id)
        {
            if (ModelState.IsValid)
            {
                message.UpdatedBy = User.Identity.Name;
                var sender = await UserManager.GetUserAsync(User);
                message.MemberId = Guid.Parse(sender.Id);
                message.CreatedBy = sender.Id;
                message.ToSendId = Guid.Parse(id);
                message.CreatedDate = DateTime.Now;
                message.UpdatedDate = DateTime.Now;
                await Ctx.TbMessages.AddAsync(message);
                await Ctx.SaveChangesAsync();
                ViewBag.Tosend = id;
                var currentUser = await UserManager.GetUserAsync(User);
                if (User.Identity.IsAuthenticated)
                {
                    ViewBag.CurrentUserName = currentUser.UserName;
                }
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                string strCurrentUserId = User.Identity.Name;
                oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, id);
                var messages = await Ctx.TbMessages.ToListAsync();
                return Redirect("/Home/Index/");
                //return Redirect("/Home/NewChat/");
                //return Ok();
            }
            return Error();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Chat()
        {
            var CurrentUser = await UserManager.GetUserAsync(User);
            ViewBag.CurrentUserName = CurrentUser.UserName;
            var message = await Ctx.TbMessages.ToListAsync();
            return View(message);
        }
        public async Task<IActionResult> Create(TbMessage message)
        {
            if (ModelState.IsValid)
            {
                message.UpdatedBy = User.Identity.Name;
                var Sender = await UserManager.GetUserAsync(User);
                message.MemberId = Guid.Parse(Sender.Id);
                await Ctx.TbMessages.AddAsync(message);
                await Ctx.SaveChangesAsync();
                return Ok();
            }
            return View();



        }









        public IActionResult Index10()
        {
            string strCurrentUserName = User.Identity.Name;
            List<TbMessage> o = new List<TbMessage>();
            if (strCurrentUserName != null)
            {
                string strCurrentUserId = UserManager.Users.Where(a => a.Email == strCurrentUserName).FirstOrDefault().Id;


                o = Ctx.TbMessages.Where(a => a.ToSendId == Guid.Parse(strCurrentUserId)).ToList();
            }


            return View();
        }
        public IActionResult Index20()
        {
            string strCurrentUserName = User.Identity.Name;
            List<TbMessage> o = new List<TbMessage>();
            if (strCurrentUserName !=null) 
            {
                string strCurrentUserId = UserManager.Users.Where(a => a.Email == strCurrentUserName).FirstOrDefault().Id;


                o = Ctx.TbMessages.Where(a => a.ToSendId == Guid.Parse(strCurrentUserId)).ToList();
            }
           
            return Ok(o);
        }

        public IActionResult Index30(string id)
        {
            TbMessage oTbPerson = Ctx.TbMessages.Where(a => a.MessagesId == Guid.Parse(id)).FirstOrDefault();
            List<TbMessage> o = new List<TbMessage>();
            o = Ctx.TbMessages.ToList();
            o.Remove(oTbPerson);
            Ctx.Entry(oTbPerson).State = EntityState.Deleted;
            Ctx.SaveChanges();

            return RedirectToAction("NewChat");
           
        }

        public IActionResult GetNotificationContacts()
        {
            var currentTime = DateTime.Now;
            //var notificationregistertime = HttpContext.Session.GetObjectFromJson<DateTime>("cart");


            SqlDependencyService NC = new SqlDependencyService();
            var list = NC.GetContacts();

            return View();
        }
        #endregion

        #endregion
    }
}
