using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VipAssistProject.Bl;
using VipAssistProject.Models;

namespace VipAssistProject.Controllers
{
    public class UserController : Controller
    {
        ISliderImagesServices SliderImagesServices;
        VipAssistDatabaseContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;
        IClsSalesInvoice ClsSalesInvoice;
        IClsSalesInvoiceServices ClsSalesInvoiceServices;
        IServiceMediasServices ServiceMediasServices;
        public UserController(IServiceMediasServices serviceMediasServices , IClsSalesInvoiceServices clsSalesInvoiceServices , IClsSalesInvoice clsSalesInvoice, ISliderImagesServices sliderImagesServices, VipAssistDatabaseContext ctx ,UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Usermanager = usermanager;
            SignInManager = signInManager;
            Ctx = ctx;
            SliderImagesServices = sliderImagesServices;
            ClsSalesInvoice = clsSalesInvoice;
            ClsSalesInvoiceServices = clsSalesInvoiceServices;
            ServiceMediasServices = serviceMediasServices;
    }
        

        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(HomePageModel oHomePageModel)
        {
            try 
            {
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                //if (ModelState.IsValid)
                //{
                //    var user = new ApplicationUser()
                //    {
                //        Email = oHomePageModel.Email,
                //        UserName = oHomePageModel.Email

                //    };
                //    var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                //    if (result.Succeeded)
                //    {





                //        result.ToString();

                //        return Redirect("~/");
                //    }
                //    else
                //    {
                //        var error = result.Errors.ToList();
                //        string erresult = "";
                //        string erresult2 = "";
                //        foreach (var er in error)
                //        {
                //            erresult = string.Format("{0}\t\t{1}", erresult, er.Description);



                //        }

                //        this.ModelState.AddModelError("Password", erresult);
                //        this.ModelState.AddModelError("Email", erresult2);
                //        return View("LogIn", oHomePageModel);
                //    }
                //}
                //else
                //{
                //    return View("LogIn", oHomePageModel);
                //}

               
                    var user = new ApplicationUser()
                    {
                        Email = oHomePageModel.Email,
                        UserName = oHomePageModel.Email

                    };
                    var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                    if (result.Succeeded)
                    {





                        result.ToString();

                        return Redirect("~/");
                    }
                    else
                    {
                       
                        return View("LogIn", oHomePageModel);
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
        [HttpPost]
        public async Task<IActionResult> LogInn(HomePageModel oHomePageModel)
        {
            try 
            {
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await SignInManager.PasswordSignInAsync(oHomePageModel.Email, oHomePageModel.Password, true, true);
                if (string.IsNullOrEmpty(oHomePageModel.ReturnUrl))
                {
                    oHomePageModel.ReturnUrl = "~/";
                }
                if (result.Succeeded)
                {




                    result.ToString();
                    return Redirect(oHomePageModel.ReturnUrl);
                }
                else
                {



                    ViewBag.one = "invalid Email or Invalid Password";
                    //this.ModelState.AddModelError("Password", erresult );
                    //this.ModelState.AddModelError( "Email", erresult2);
                    //erresult = "Password";
                    //erresult2 = "Email";
                }
                return View("LogIn", oHomePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }

        }




        public async Task<IActionResult> SignIn(HomePageModel oHomePageModel)
        {
            try 
            {
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();

                var result = await SignInManager.PasswordSignInAsync(oHomePageModel.Email, oHomePageModel.Password, true, true);
                if (string.IsNullOrEmpty(oHomePageModel.ReturnUrl))
                {
                    oHomePageModel.ReturnUrl = "~/";
                }
                if (result.Succeeded)
                {



                    result.ToString();
                    return Redirect(oHomePageModel.ReturnUrl);
                }
                else
                {



                    ViewBag.one = "invalid Email or Invalid Password";
                    //this.ModelState.AddModelError("Password", erresult );
                    //this.ModelState.AddModelError( "Email", erresult2);
                    //erresult = "Password";
                    //erresult2 = "Email";
                }
                return View("LogIn", oHomePageModel);
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }


        }
        public async Task<IActionResult> LogOut()
        {

            await SignInManager.SignOutAsync();


            return Redirect("~/");

        }
        public IActionResult LogIn(string ReturnUrl)
        {
            try 
            {
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                oHomePageModel.user = new UserModel()
                {
                    ReturnUrl = ReturnUrl
                };


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
        public IActionResult AccessDenied()
        {
            try 
            {
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
    }
}
