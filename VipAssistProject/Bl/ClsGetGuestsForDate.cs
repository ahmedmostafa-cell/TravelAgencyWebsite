using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using VipAssistProject.Models;
namespace VipAssistProject.Bl
{
    public interface IGetNOTIFICATIONS
    {
        IEnumerable<GetNOTIFICATIONS> GetAll(string strCurrentUserId);

    }
    public class ClsGetGuestsForDate : IGetNOTIFICATIONS
    {

        private string connectionString;
        VipAssistDatabaseContext ctx;
        public ClsGetGuestsForDate(VipAssistDatabaseContext contex)
        {
            ctx = contex;
            connectionString = @"Server=DESKTOP-ABVI0A5\MSSQLSERVER01;Database=VipAssistDatabaseNew;Trusted_Connection=True";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }



        public IEnumerable<GetNOTIFICATIONS> GetAll(string strCurrentUserId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string id = ctx.Users.Where(a => a.Email == strCurrentUserId).FirstOrDefault().Id;
                var SQL = string.Format("EXECUTE dbo.GetNOTIFICATIONS @ID=[{0}]", id);
                return dbConnection.Query<GetNOTIFICATIONS>(SQL);
            }
        }






    }
    
}
