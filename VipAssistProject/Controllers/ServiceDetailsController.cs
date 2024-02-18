using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Bl;
using VipAssistProject.Models;
namespace VipAssistProject.Controllers
{

    public class ServiceDetailsController : Controller
    {
       

        #region Declaration
        VipAssistDatabaseContext Ctx;
        ISliderImagesServices SliderImagesServices;
        IServiceMediasServices ServiceMediasServices;
        IServicesServices ServicesServices;
        IGetChat Eight;
        private readonly UserManager<ApplicationUser> UserManager;
        public ServiceDetailsController(UserManager<ApplicationUser> userManager, IGetChat eight , IServicesServices servicesServices , VipAssistDatabaseContext ctx, ISliderImagesServices sliderImagesServices, IServiceMediasServices serviceMediasServices)
        {
            Ctx = ctx;
            SliderImagesServices = sliderImagesServices;
            ServiceMediasServices = serviceMediasServices;
            ServicesServices = servicesServices;
            Eight = eight;
            UserManager = userManager;
        }

        #endregion
        public IActionResult Index()
        {
            
            return View();

        }
        public IActionResult Test()
        {

            return View();

        }


        public IActionResult Test2(Guid id , string f , string ide)
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
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.ServiceCategoryId == id).Where(a => a.CurrentState == 0 && a.IsDefault == true).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();

                oHomePageModel.LstCars = Ctx.TbLanguages.ToList();
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



        public IActionResult Test3(Guid id , Guid foo)
        {

          

            try
            {
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.ServiceCategoryId == id).Where(a => a.CurrentState == 0 && a.IsDefault == true).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();

                oHomePageModel.LstCars = Ctx.TbLanguages.ToList().Where(a=> a.LanguageId== id);
                string carname = Ctx.TbLanguages.ToList().Where(a => a.LanguageId == id).FirstOrDefault().LanguageName;
                ShoppingCart oShoppingCart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                if (oShoppingCart == null)
                {
                    oShoppingCart = new ShoppingCart();
                    oShoppingCart.Count = 0;
                }
                TbService oTbService = ServicesServices.GetServicesWithDiscount().Where(a => a.ServiceId == foo).FirstOrDefault();
                ShoppingCartItems item = oShoppingCart.LstServices.Where(a => a.ServiceId == foo).FirstOrDefault();
                if (item != null)
                {
                    item.Qty++;
                    item.Total = item.Qty * item.Price;
                    oShoppingCart.Count++;
                }
                else
                {
                    oShoppingCart.LstServices.Add(new ShoppingCartItems()
                    {
                        ServiceId = oTbService.ServiceId,
                        TitleEn = oTbService.TitleEn,
                        TitleFr = oTbService.TitleFr,
                        Path = oTbService.TbServiceMedia.FirstOrDefault().Path,
                        Price = oTbService.Price,
                        CarName = carname,


                        Qty = 1,
                        Total = oTbService.Price,


                    });
                    oShoppingCart.Count++;
                }

                oShoppingCart.Total = oShoppingCart.LstServices.Sum(a => a.Total);
                HttpContext.Session.SetObjectAsJson("cart", oShoppingCart);
                ViewBag.Cart = oShoppingCart.Count;
                return Redirect("/Order/Cart/");
               
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }

        }
        public IActionResult Details(Guid id)
        {
            try 
            {
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.ServiceCategoryId == id).Where(a => a.CurrentState == 0 && a.IsDefault == true).ToList();
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


        public IActionResult BookingDetails1(Guid id , string f , string foo , string ide)
        {

            ViewBag.ServiceId = id;
            ViewBag.CarId = foo;
            try
            {
                string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
                string SenderId = "";
                if (ide != null)
                {
                    SenderId = Ctx.Users.Where(a => a.Email == ide).FirstOrDefault().Id;
                }
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.ServiceCategoryId == id).Where(a => a.CurrentState == 0 && a.IsDefault == true).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();

                oHomePageModel.LstCars = Ctx.TbLanguages.ToList();
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


        public IActionResult BookingDetails2(Guid id, string f , string l , string ide)
        {
            ViewBag.ServiceId = id;
            ViewBag.FlightStatus = f;
           

            try
            {
                string idd = "e67f0a6e-c5e2-44be-a34c-0f33c961e356";
                string SenderId = "";
                if (ide != null)
                {
                    SenderId = Ctx.Users.Where(a => a.Email == ide).FirstOrDefault().Id;
                }
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.LstServicesWithMedia = Ctx.VwGetServiceList.Where(a => a.ServiceCategoryId == id).Where(a => a.CurrentState == 0 && a.IsDefault == true).ToList();
                oHomePageModel.LstServicesWithMediaSubMenue = Ctx.VwGetServiceList.Where(a => a.CurrentState == 1).ToList();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oHomePageModel.LstSliderImages = SliderImagesServices.GetAllSliderImages();
                oHomePageModel.UserData = ServiceMediasServices.LstUsersData();
                if(l!=null) 
                {
                    oHomePageModel.LstCars = Ctx.TbLanguages.ToList();
                    oHomePageModel.LstCars = Ctx.TbLanguages.ToList().Where(a => a.LanguageId == Guid.Parse(l));
                    string carname = Ctx.TbLanguages.ToList().Where(a => a.LanguageId == Guid.Parse(l)).FirstOrDefault().LanguageName;
                    ViewBag.CarName = carname;
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
        public IActionResult AddToCart(Guid id , string FlightStatus, string FlightDate , string FlightName , int PersonQty , int InfantQty , int BagQty , string CarName)
        {
            try 
            {
                ShoppingCart oShoppingCart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                if (oShoppingCart == null)
                {
                    oShoppingCart = new ShoppingCart();
                    oShoppingCart.Count = 0;
                }
                TbService oTbService = ServicesServices.GetServicesWithDiscount().Where(a => a.ServiceId == id).FirstOrDefault();
                ShoppingCartItems item = oShoppingCart.LstServices.Where(a => a.ServiceId == id).FirstOrDefault();
                if (item != null)
                {
                    item.Qty++;
                    item.Total = item.Qty * item.Price;
                    oShoppingCart.Count++;
                }
                else
                {
                    oShoppingCart.LstServices.Add(new ShoppingCartItems()
                    {
                        ServiceId = oTbService.ServiceId,
                        TitleEn = oTbService.TitleEn,
                        TitleFr = oTbService.TitleFr,
                        Path = oTbService.TbServiceMedia.FirstOrDefault().Path,
                        Price = oTbService.Price,
                        FlightStatus = FlightStatus,
                        FlightDate = FlightDate,

                        FlightName = FlightName,

                        PersonQty= PersonQty,

                        InfantQty= InfantQty,

                        BagQty= BagQty,
                        CarName = CarName,



                        Qty = 1,
                        Total = oTbService.Price,


                    });
                    oShoppingCart.Count++;
                }

                oShoppingCart.Total = oShoppingCart.LstServices.Sum(a => a.Total);
                HttpContext.Session.SetObjectAsJson("cart", oShoppingCart);
                ViewBag.Cart = oShoppingCart.Count;
                return Redirect("/Order/Cart/");

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }

        }
        public IActionResult RemoveFromCart(Guid id)

        {
            try 
            {
                HomePageModel oHomePageModel = new HomePageModel();

                ShoppingCartItems oShoppingCartItems = new ShoppingCartItems();
                oHomePageModel.Cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("cart");
                oShoppingCartItems = oHomePageModel.Cart.LstServices.Where(a => a.ServiceId == id).FirstOrDefault();
                oHomePageModel.Cart.LstServices.Remove(oShoppingCartItems);

                oHomePageModel.Cart.Count = oHomePageModel.Cart.Count - oShoppingCartItems.Qty;
                oHomePageModel.Cart.Total = oHomePageModel.Cart.LstServices.Sum(a => a.Total);



                HttpContext.Session.SetObjectAsJson("cart", oHomePageModel.Cart);
                return Redirect("/Order/Cart/");
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
