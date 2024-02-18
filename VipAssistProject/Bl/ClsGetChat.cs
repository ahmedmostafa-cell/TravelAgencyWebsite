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
    public interface IGetChat
    {
        IEnumerable<GetChats> GetAll(string strCurrentUserId , string senderId);

    }
    public class ClsGetChat : IGetChat
    {

        private string connectionString;
        VipAssistDatabaseContext ctx;
        public ClsGetChat(VipAssistDatabaseContext contex)
        {
            ctx = contex;
            connectionString = @"Server=DESKTOP-262OT74\MSSQLSERVER01;Database=db_a788b5_habibaahmedmm;Trusted_Connection=True";
            //connectionString = @"Server=SQL5103.site4now.net;Database=db_a788b5_habibaahmedm;User Id=db_a788b5_habibaahmedm_admin;Password=2812008a1";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }



        public IEnumerable<GetChats> GetAll(string strCurrentUserId , string senderId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                string id = ctx.Users.Where(a => a.Email == strCurrentUserId).FirstOrDefault().Id;
                var SQL = string.Format("EXECUTE dbo.GetChat @ID=[{0}] , @ID2=[{1}]", id, senderId);
                IEnumerable<GetChats>  GetAll = dbConnection.Query<GetChats>(SQL);
                return GetAll;
            }
        }






    }
}
