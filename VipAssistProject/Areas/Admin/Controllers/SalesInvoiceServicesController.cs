using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Bl;

using VipAssistProject.Models;
using Domains;
using Microsoft.AspNetCore.Http;
using EmailService;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace VipAssistProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SalesInvoiceServicesController : Controller
    {
        IClsSalesInvoiceServices _ClsSalesInvoiceServices;
        VipAssistDatabaseContext Ctx;
        ISliderImagesServices SliderImagesServices;
        IServiceMediasServices ServiceMediasServices;
        IClsSalesInvoice ClsSalesInvoice;
        
        IEmailSender _emailSender;
        SignInManager<ApplicationUser> SignInManager;
        public SalesInvoiceServicesController(SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, IClsSalesInvoice clsSalesInvoice, VipAssistDatabaseContext ctx, ISliderImagesServices sliderImagesServices, IServiceMediasServices serviceMediasServices, IClsSalesInvoiceServices ClsSalesInvoiceServices)
        {
            _ClsSalesInvoiceServices = ClsSalesInvoiceServices;

            Ctx = ctx;
            SliderImagesServices = sliderImagesServices;
            ServiceMediasServices = serviceMediasServices;
            ClsSalesInvoice = clsSalesInvoice;
           
            _emailSender = emailSender;
            SignInManager = signInManager;

        }
        public IActionResult Index()


        {

            try
            {
                List<TbSalesInvoiceService> LstTbSalesInvoiceService = _ClsSalesInvoiceServices.GetAllServices();
                if (HttpContext.Session.GetString("message") != null)
                {

                    ViewBag.message = HttpContext.Session.GetString("message");
                }
                else
                {
                    ViewBag.message = null;
                }

                SalesInvoicePageModel oSalesInvoicePageModel = new SalesInvoicePageModel();
                oSalesInvoicePageModel.LstTbSalesInvoiceService = LstTbSalesInvoiceService;



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

        public IActionResult GetInvoiceDetails(string id)


        {
            string f = id.Substring(2, (id.Length - 4));
            try
            {
                List<InvoiceDetailsNew> LstInvoiceDetails = _ClsSalesInvoiceServices.GetInvoiceDetailsNew(Guid.Parse(f));
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


        public IActionResult Delete(Guid id)
        {
            try
            {
                bool result = _ClsSalesInvoiceServices.Delete(id);
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


        public IActionResult GetLoyalityPoints()
        {
            try
            {
                List<VwLoyalityPoints> LstLoyality = new List<VwLoyalityPoints>();
                LstLoyality = Ctx.VwLoyalityPoints.ToList();
                SalesInvoicePageModel oSalesInvoicePageModel = new SalesInvoicePageModel();
                oSalesInvoicePageModel.LstLoyalityPoints = LstLoyality;
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


        [HttpGet]

        public async Task<IActionResult> ReplyToCustomer(Guid id , string fd)
        {
            try
            {
                HomePageModel oHomePageModel = new HomePageModel();


                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                oHomePageModel.LstVwViewServiceMemberOrder = ClsSalesInvoice.GetMemeberOrders(Guid.Parse(userId));
                TbSalesInvoiceService invoice = new TbSalesInvoiceService();
                 invoice = _ClsSalesInvoiceServices.GetItemByIdInvoiceId(id);
                if(invoice.LoyalityPoints>0) 
                {
                    invoice.LoyalityPoints++;
                }
                else
                    invoice.LoyalityPoints = 1;
                Ctx.Entry(invoice).State = EntityState.Modified;
                Ctx.SaveChanges();

                var userEmail = User.FindFirstValue(ClaimTypes.Email);

                var message = new Message(new string[] { fd }, "The Booking Is Confirmed", "This is the content from our async email. i am happy", null);
                await _emailSender.SendEmailAsyncToCustomerWithBookingDetails(message , id);
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



        public async Task<IActionResult> ReplyToCustomerWithMessage(string Comment , string CustomerEmail)
        {
            try
            {
                HomePageModel oHomePageModel = new HomePageModel();


                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                oHomePageModel.LstVwViewServiceMemberOrder = ClsSalesInvoice.GetMemeberOrders(Guid.Parse(userId));



                var userEmail = User.FindFirstValue(ClaimTypes.Email);

                var message = new Message(new string[] { CustomerEmail }, "The Booking Is not Confirmed", "This is the content from our async email. i am happy", null);
                await _emailSender.SendEmailAsyncToCustomerNotConfirmedBooking(message , Comment, CustomerEmail);
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


        public IActionResult ReplyToCustomerNotConfirmed(string id)
        {

            ViewBag.CustomerEmail = id;

            return View();


        }
    }
}
