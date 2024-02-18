using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VipAssistProject.Models;

namespace VipAssistProject.Bl
{
    public interface IClsSalesInvoiceServices
    {
        List<TbSalesInvoiceService> GetAllServices();
        List<InvoiceDetails> GetInvoiceDetails(Guid id);

        List<InvoiceDetailsNew> GetInvoiceDetailsNew(Guid id);
        TbSalesInvoiceService GetItemById(Guid? id);

        TbSalesInvoiceService GetItemByIdInvoiceId(Guid? id);
        
        bool Add(TbSalesInvoiceService item);
        bool Edit(TbSalesInvoiceService item);
        bool Delete(Guid id);
        
    }
    public class ClsSalesInvoiceServices : IClsSalesInvoiceServices
    {
        VipAssistDatabaseContext Ctx;
        public ClsSalesInvoiceServices(VipAssistDatabaseContext contxet)
        {
            Ctx = contxet;
        }


        public List<TbSalesInvoiceService> GetAllServices()
        {
            try
            {

                List<TbSalesInvoiceService> LstSalesInvoiceService = Ctx.TbSalesInvoiceServices.Include(a=> a.Service).ToList();
                return LstSalesInvoiceService;

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }



        }


        public List<InvoiceDetails> GetInvoiceDetails(Guid id)
        {
            try
            {

                List<InvoiceDetails> LstSalesInvoiceService = Ctx.InvoiceDetails.Where(a=> a.InvoiceId == id).ToList();
                return LstSalesInvoiceService;

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }



        }




        public List<InvoiceDetailsNew> GetInvoiceDetailsNew(Guid id)
        {
            try
            {

                List<InvoiceDetailsNew> LstSalesInvoiceService = Ctx.InvoiceDetailsNew.Where(a => a.InvoiceId == id).ToList();
                return LstSalesInvoiceService;

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }



        }
        public TbSalesInvoiceService GetItemById(Guid? id)
        {
            try
            {

                TbSalesInvoiceService oTbSalesInvoiceService = Ctx.TbSalesInvoiceServices.Where(a => a.InvoiceServiceId == id).FirstOrDefault();
                return oTbSalesInvoiceService;
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }

        }



        public TbSalesInvoiceService GetItemByIdInvoiceId(Guid? id)
        {
            try
            {

                TbSalesInvoiceService oTbSalesInvoiceService = Ctx.TbSalesInvoiceServices.Where(a => a.InvoiceId == id).FirstOrDefault();
                return oTbSalesInvoiceService;
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }

        }



        public bool Add(TbSalesInvoiceService item)
        {
            try
            {

                Ctx.TbSalesInvoiceServices.Add(item);
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



        public bool Edit(TbSalesInvoiceService item)
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


        public bool Delete(Guid id)
        {
            try
            {

                TbSalesInvoiceService oTbSalesInvoiceService = Ctx.TbSalesInvoiceServices.Where(a => a.InvoiceServiceId == id).FirstOrDefault();
                Ctx.TbSalesInvoiceServices.Remove(oTbSalesInvoiceService);

                Ctx.Entry(oTbSalesInvoiceService).State = EntityState.Deleted;
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
    }
}
