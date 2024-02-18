using Domains;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VipAssistProject.Bl;
using VipAssistProject.Models;

namespace VipAssistProject.Controllers
{
    public class OrderController : Controller
    {
        #region Declarartion
        VipAssistDatabaseContext Ctx;
        ISliderImagesServices SliderImagesServices;
        IServiceMediasServices ServiceMediasServices;
        IClsSalesInvoice ClsSalesInvoice;
        IClsSalesInvoiceServices ClsSalesInvoiceServices;
        IEmailSender _emailSender;
        SignInManager<ApplicationUser> SignInManager;
        IGetChat Eight;
        private readonly UserManager<ApplicationUser> UserManager;
        /// <summary>
        /// Adding Interface to Dependency Injection
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="sliderImagesServices"></param>
        /// <param name="serviceMediasServices"></param>

        public OrderController(UserManager<ApplicationUser> userManager, IGetChat eight, SignInManager<ApplicationUser> signInManager , IEmailSender emailSender, IClsSalesInvoice clsSalesInvoice , IClsSalesInvoiceServices clsSalesInvoiceServices, VipAssistDatabaseContext ctx, ISliderImagesServices sliderImagesServices, IServiceMediasServices serviceMediasServices)
        {
            Ctx = ctx;
            SliderImagesServices = sliderImagesServices;
            ServiceMediasServices = serviceMediasServices;
            ClsSalesInvoice = clsSalesInvoice;
            ClsSalesInvoiceServices = clsSalesInvoiceServices;
            _emailSender = emailSender;
            SignInManager = signInManager;
            Eight = eight;
            UserManager = userManager;
        }

        #endregion
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cart(string ide)
        {
            try 
            {
                string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
                string SenderId = "";
                if (ide != null)
                {
                    SenderId = Ctx.Users.Where(a => a.Email == ide).FirstOrDefault().Id;
                }
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                if (oHomePageModel.Cart == null)
                {
                    ViewBag.cart = "";
                    ViewBag.cartTotal = "";

                }
                else
                {
                    ViewBag.cart = oHomePageModel.Cart.Count;
                    ViewBag.cartTotal = oHomePageModel.Cart.Total;
                    

                }
                string strCurrentUserId = User.Identity.Name;
                if (strCurrentUserId != null)
                {
                    if (ide == null)
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
                    if (ide == null)
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
        public IActionResult Test()
        {
            HomePageModel oHomePageModel = new HomePageModel();


            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            return View(oHomePageModel);

        }


        [Authorize]
        public IActionResult CheckOut(string ide)
        {
            try 
            {
                string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
                string SenderId = "";
                if (ide != null)
                {
                    SenderId = Ctx.Users.Where(a => a.Email == ide).FirstOrDefault().Id;
                }
                HomePageModel oHomePageModel = new HomePageModel();


                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                oHomePageModel.LstTbPaymentMethod = Ctx.TbPaymentMethods.ToList();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.FlightDate = oHomePageModel.Cart.LstServices.FirstOrDefault().FlightDate;
                ViewBag.FlightName = oHomePageModel.Cart.LstServices.FirstOrDefault().FlightName;
                ViewBag.FlightStatus = oHomePageModel.Cart.LstServices.FirstOrDefault().FlightStatus;
                ViewBag.PersonQty = oHomePageModel.Cart.LstServices.FirstOrDefault().PersonQty;
                ViewBag.InfantQty = oHomePageModel.Cart.LstServices.FirstOrDefault().InfantQty;
                ViewBag.BagQty = oHomePageModel.Cart.LstServices.FirstOrDefault().BagQty;
                ViewBag.CarName = oHomePageModel.Cart.LstServices.FirstOrDefault().CarName;
                string strCurrentUserId = User.Identity.Name;
                if (strCurrentUserId != null)
                {
                    if (ide == null)
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
                    if (ide == null)
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PlaceOrderAsync(string FlightStatus, string FlightDate, string FlightName, string PersonQty, string InfantQty, string BagQty , string CarName , string ide)
        {
            try 
            {
                string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
                string SenderId = "";
                if (ide != null)
                {
                    SenderId = Ctx.Users.Where(a => a.Email == ide).FirstOrDefault().Id;
                }
                HomePageModel oHomePageModel = new HomePageModel();


                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                oHomePageModel.LstVwViewServiceMemberOrder = ClsSalesInvoice.GetMemeberOrders(Guid.Parse(userId));
                TbSalesInvoice oTbSalesInvoice = new TbSalesInvoice();
                oTbSalesInvoice.CreatedBy = userId;
                oTbSalesInvoice.CreatedDate = DateTime.Now;
                oTbSalesInvoice.InvoiceDate = DateTime.Now;
                oTbSalesInvoice.UpdatedDate =DateTime.Parse(FlightDate);
                oTbSalesInvoice.InvoiceId = Guid.NewGuid();
                oTbSalesInvoice.MemberId = userId;
                ClsSalesInvoice.Add(oTbSalesInvoice);
                Guid InvoiceNumber = oTbSalesInvoice.InvoiceId;
                if (oHomePageModel.Cart != null)
                {
                    foreach (var service in oHomePageModel.Cart.LstServices)
                    {
                        TbSalesInvoiceService oTbSalesInvoiceService = new TbSalesInvoiceService();
                        oTbSalesInvoiceService.InvoiceServiceId = Guid.NewGuid();
                        oTbSalesInvoiceService.InvoiceId = InvoiceNumber;
                        oTbSalesInvoiceService.ServiceId = service.ServiceId;
                        oTbSalesInvoiceService.Qty = service.Qty;
                        //oTbSalesInvoiceService.InvoicePrice = oTbSalesInvoiceService.Qty * service.Price;
                        oTbSalesInvoiceService.InvoicePrice = int.Parse(BagQty);
                        oTbSalesInvoiceService.CreatedBy = userId;
                        oTbSalesInvoiceService.CreatedDate = DateTime.Now;
                        oTbSalesInvoiceService.UpdatedDate = DateTime.Parse(FlightDate);
                        oTbSalesInvoiceService.NotesAr = FlightStatus;
                        oTbSalesInvoiceService.NotesEn = FlightName;
                        oTbSalesInvoiceService.NotesFr = PersonQty;
                        oTbSalesInvoiceService.UpdatedBy = InfantQty;
                        oTbSalesInvoiceService.CarName = CarName;
                        ClsSalesInvoiceServices.Add(oTbSalesInvoiceService);
                       

                    }
                }
                // i hold email service as my domain is expired
                //var userEmail = User.FindFirstValue(ClaimTypes.Email);
                
                //var message = new Message(new string[] { "ahmedmostafa706@gmail.com" }, "Email From Customer", "This is the content from our async email. i am happy", null);
                
                //await _emailSender.SendEmailAsync(message , InvoiceNumber);
               
                HttpContext.Session.Clear();
                string strCurrentUserId = User.Identity.Name;
                if (strCurrentUserId != null)
                {
                    if (ide == null)
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
                    if (ide == null)
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, idd);
                    }
                    else
                    {
                        oHomePageModel.LstChats = Eight.GetAll(strCurrentUserId, SenderId);
                    }
                }
                return View("Unfortuantely", oHomePageModel);

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }


        }

        public  IActionResult Unfortuantely()
        {
            try
            {
             
                HomePageModel oHomePageModel = new HomePageModel();


                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
               


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

        public async Task<IActionResult> ReplyToCustomer(string CustomerEmail)
        {
            try
            {
                HomePageModel oHomePageModel = new HomePageModel();


                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                oHomePageModel.LstVwViewServiceMemberOrder = ClsSalesInvoice.GetMemeberOrders(Guid.Parse(userId));
               
               

                var userEmail = User.FindFirstValue(ClaimTypes.Email);

                var message = new Message(new string[] { CustomerEmail }, "Email From Customer", "This is the content from our async email. i am happy", null);
                await _emailSender.SendEmailAsyncToCustomer(message);
                HttpContext.Session.Clear();
                return Redirect("~/");

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }


        }



        [HttpPost]
        public async Task<IActionResult> PlaceOrderAsyncWithFiles()
        {
            try
            {
                HomePageModel oHomePageModel = new HomePageModel();


                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                oHomePageModel.LstVwViewServiceMemberOrder = ClsSalesInvoice.GetMemeberOrders(Guid.Parse(userId));
                TbSalesInvoice oTbSalesInvoice = new TbSalesInvoice();
                oTbSalesInvoice.CreatedBy = userId;
                oTbSalesInvoice.CreatedDate = DateTime.Now;
                oTbSalesInvoice.InvoiceDate = DateTime.Now;
                oTbSalesInvoice.InvoiceId = Guid.NewGuid();
                oTbSalesInvoice.MemberId = userId;
                ClsSalesInvoice.Add(oTbSalesInvoice);
                Guid InvoiceNumber = oTbSalesInvoice.InvoiceId;
                if (oHomePageModel.Cart != null)
                {
                    foreach (var service in oHomePageModel.Cart.LstServices)
                    {
                        TbSalesInvoiceService oTbSalesInvoiceService = new TbSalesInvoiceService();
                        oTbSalesInvoiceService.InvoiceServiceId = Guid.NewGuid();
                        oTbSalesInvoiceService.InvoiceId = InvoiceNumber;
                        oTbSalesInvoiceService.ServiceId = service.ServiceId;
                        oTbSalesInvoiceService.Qty = service.Qty;
                        oTbSalesInvoiceService.InvoicePrice = oTbSalesInvoiceService.Qty * service.Price;
                        oTbSalesInvoiceService.CreatedBy = userId;
                        oTbSalesInvoiceService.CreatedDate = DateTime.Now;

                        ClsSalesInvoiceServices.Add(oTbSalesInvoiceService);
                        HttpContext.Session.Clear();
                    }
                }


                var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();

                var message = new Message(new string[] { "nevinec914@flipssl.com" }, "Test mail with Attachments", "This is the content from our mail with attachments.", files);
                await _emailSender.SendEmailAsync(message , InvoiceNumber);

                return Redirect("~/");

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }


        }

        public IActionResult CustomerInvoicesHistory() 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            HomePageModel oHomePageModel = new HomePageModel();


            oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
            oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
            oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
            oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
            oHomePageModel.LstSalesInvoice = Ctx.TbSalesInvoices.Where(A=> A.MemberId == userId).ToList();
            oHomePageModel.LstSalesInvoiceService = Ctx.TbSalesInvoiceServices.Where(a => a.CreatedBy == userId).ToList();
            int? LoyALITYpoints = oHomePageModel.LstSalesInvoiceService.Sum(a => a.LoyalityPoints);
            ViewBag.LoyalityPoints = LoyALITYpoints;
            return View(oHomePageModel);
        }

        public IActionResult CustomerInvoicesDetails(string id)
        {

            string f = id.Substring(2, (id.Length - 4));
            try
            {
                List<InvoiceDetailsNew> LstInvoiceDetails = ClsSalesInvoiceServices.GetInvoiceDetailsNew(Guid.Parse(f));
                if (HttpContext.Session.GetString("message") != null)
                {

                    ViewBag.message = HttpContext.Session.GetString("message");
                }
                else
                {
                    ViewBag.message = null;
                }

                SalesInvoicePageModel oSalesInvoicePageModel = new SalesInvoicePageModel();
                oSalesInvoicePageModel.LstInvoiceDetailsNew = LstInvoiceDetails;



                return View(oSalesInvoicePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                RedirectToAction("Error", "Home", ex.Message);
                return null;

            }

        }


        public IActionResult CustomerInvoicesDetailsss(Guid id)
        {

            
            try
            {
                List<InvoiceDetailsNew> LstInvoiceDetails = ClsSalesInvoiceServices.GetInvoiceDetailsNew(id);
                if (HttpContext.Session.GetString("message") != null)
                {

                    ViewBag.message = HttpContext.Session.GetString("message");
                }
                else
                {
                    ViewBag.message = null;
                }

                SalesInvoicePageModel oSalesInvoicePageModel = new SalesInvoicePageModel();
                oSalesInvoicePageModel.LstInvoiceDetailsNew = LstInvoiceDetails;



                return View(oSalesInvoicePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                RedirectToAction("Error", "Home", ex.Message);
                return null;

            }

        }
        public IActionResult CustomerInvoicesDetailss(Guid id)
        {


            try
            {
                List<InvoiceDetailsNew> LstInvoiceDetails = ClsSalesInvoiceServices.GetInvoiceDetailsNew(id);
                if (HttpContext.Session.GetString("message") != null)
                {

                    ViewBag.message = HttpContext.Session.GetString("message");
                }
                else
                {
                    ViewBag.message = null;
                }

                SalesInvoicePageModel oSalesInvoicePageModel = new SalesInvoicePageModel();
                oSalesInvoicePageModel.LstInvoiceDetailsNew = LstInvoiceDetails;



                return View(oSalesInvoicePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                RedirectToAction("Error", "Home", ex.Message);
                return null;

            }

        }
    }
}













