using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Models;
using Domains;
namespace VipAssistProject.Bl
{
    public interface IClsSalesInvoice
    {
        

        List<TbSalesInvoice> GetAllServices(Guid MemberId);
        List<TbSalesInvoice> GetAllServicesWithoutMemberId();
        List<InvoicesSummary> GetInvoicesSummary();
        List<VwViewServiceMemberOrderr> GetMemeberOrders(Guid MemberId);
        TbSalesInvoice GetItemById(Guid? id);
        bool Add(TbSalesInvoice item);
        bool Edit(TbSalesInvoice item);
        bool Delete(Guid id);
        
    }
    public class ClsSalesInvoice : IClsSalesInvoice
    {
        VipAssistDatabaseContext Ctx;
        public ClsSalesInvoice(VipAssistDatabaseContext contxet)
        {
            Ctx = contxet;
        }

        public List<TbSalesInvoice> GetAllServices(Guid MemberId)
        {
            try
            {

                List<TbSalesInvoice> LstSalesInvoice = Ctx.TbSalesInvoices.Where(a=> a.MemberId== MemberId.ToString()).ToList();
                return LstSalesInvoice;

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }



        }




        public List<TbSalesInvoice> GetAllServicesWithoutMemberId()
        {
            try
            {

                List<TbSalesInvoice> LstSalesInvoice = Ctx.TbSalesInvoices.ToList();
                return LstSalesInvoice;

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }



        }



        public List<InvoicesSummary> GetInvoicesSummary()
        {
            try
            {

                List<InvoicesSummary> LstInvoicesSummary = Ctx.InvoicesSummary.ToList();
                return LstInvoicesSummary;

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }



        }


        public TbSalesInvoice GetItemById(Guid? id)
        {
            try
            {

                TbSalesInvoice oTbSalesInvoice = Ctx.TbSalesInvoices.Where(a => a.InvoiceId == id).FirstOrDefault();
                return oTbSalesInvoice;
            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                
                return null;
            }

        }



        public bool Add(TbSalesInvoice item)
        {
            try
            {

                Ctx.TbSalesInvoices.Add(item);
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


        public bool Edit(TbSalesInvoice item)
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

                TbSalesInvoice oTbSalesInvoice = Ctx.TbSalesInvoices.Where(a => a.InvoiceId == id).FirstOrDefault();
               
                List<TbSalesInvoiceService> LstSalesInvoiceService = new List<TbSalesInvoiceService>();
                LstSalesInvoiceService = Ctx.TbSalesInvoiceServices.Where(a => a.InvoiceId == id).ToList();
                foreach(var item in LstSalesInvoiceService) 
                {
                    Ctx.TbSalesInvoiceServices.Remove(item);
                    Ctx.Entry(item).State = EntityState.Deleted;
                }
                Ctx.TbSalesInvoices.Remove(oTbSalesInvoice);
                Ctx.Entry(oTbSalesInvoice).State = EntityState.Deleted;
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

        public List<VwViewServiceMemberOrderr> GetMemeberOrders(Guid MemberId)
        {
            try
            {

                List<VwViewServiceMemberOrderr> LstSalesInvoice = Ctx.VwViewServiceMemberOrderr.Where(a => a.MemberId == MemberId.ToString()).ToList();
                return LstSalesInvoice;

            }
            catch (Exception ex)
            {
                ClsErrorLog oClsLogger = new ClsErrorLog();
                oClsLogger.SaveLog(ex);
                return null;
            }
        }
    }
}
