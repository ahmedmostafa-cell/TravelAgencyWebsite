using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Bl;
using VipAssistProject.Models;
using Domains;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace VipAssistProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SalesInvoicesController : Controller
    {
        IClsSalesInvoice _ClsSalesInvoice;
        SignInManager<ApplicationUser> SignInManager;
        public SalesInvoicesController(IClsSalesInvoice ClsSalesInvoice , SignInManager<ApplicationUser> signInManager)
        {
            _ClsSalesInvoice = ClsSalesInvoice;
            SignInManager = signInManager;


        }
        public IActionResult Index()


        {
            
            try
            {
                List<InvoicesSummary> LstSalesInvoiices = _ClsSalesInvoice.GetInvoicesSummary();
                if (HttpContext.Session.GetString("message") != null)
                {

                    ViewBag.message = HttpContext.Session.GetString("message");
                }
                else
                {
                    ViewBag.message = null;
                }

                SalesInvoicePageModel oSalesInvoicePageModel = new SalesInvoicePageModel();
                oSalesInvoicePageModel.LstInvoicesSummary = LstSalesInvoiices;



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
                bool result = _ClsSalesInvoice.Delete(id);
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
    }
}
