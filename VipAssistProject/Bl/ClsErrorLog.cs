using Domains;
using System;
using System.Collections.Generic;
using System.Text;
using VipAssistProject.Models;
namespace VipAssistProject.Bl
{
    public interface IClsErrorLog
    {
        public bool SaveLog(Exception exception);
    }

    public class ClsErrorLog : IClsErrorLog
    {
        VipAssistDatabaseContext _context;
        public ClsErrorLog(VipAssistDatabaseContext context)
        {
            _context = context;
        }

        public ClsErrorLog()
        {
            _context = new VipAssistDatabaseContext();
        }

        public bool SaveLog(Exception exception)
        {
            try
            {
                TbErrorLog logEntity = new TbErrorLog();
                if (exception.InnerException == null)
                    logEntity.InnerExceptionMessage = null;
                else
                {
                    logEntity.InnerExceptionMessage = exception.InnerException.ToString();
                }
                if (exception.Message == null) logEntity.ErrorMessage = null;
                else logEntity.ErrorMessage = exception.Message;
                if (exception.TargetSite.Name == null)
                    logEntity.MethodName = null;
                else logEntity.MethodName = exception.TargetSite.Name;
                if (exception.TargetSite.ReflectedType.FullName == null)
                    logEntity.ClassName = null;
                else logEntity.ClassName = exception.TargetSite.ReflectedType.FullName;
                if (exception.StackTrace == null)
                    logEntity.StackTrace = null;
                else logEntity.StackTrace = exception.StackTrace.ToString();
                logEntity.CreatedDate = DateTime.Now;
                logEntity.LogId = Guid.NewGuid();
                _context.TbErrorLogs.Add(logEntity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
