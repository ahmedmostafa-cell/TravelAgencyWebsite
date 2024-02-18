using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Hubs;
using VipAssistProject.Models;
namespace VipAssistProject.Bl
{
    public interface IDatabaseChangeNotificationService 
    {
        void config();
    }
    public class SqlDependencyService : IDatabaseChangeNotificationService
    {
        private readonly IConfiguration Configuration;
        private readonly IHubContext<ChatHub> ChatHub; 
        private readonly VipAssistDatabaseContext Context;
        public SqlDependencyService(VipAssistDatabaseContext context , IConfiguration configuration , IHubContext<ChatHub> chatHub) 
        {
            Configuration = configuration;

            ChatHub = chatHub;
            Context = context;
            var currentTime = DateTime.Now;
           
            subscrippersonal();
        }
        public SqlDependencyService()
        {
            
        }
        
        public void config() 
        {
            subscrippersonal();
        }
        private void subscrippersonal ( ) 
        {
            string connectionstring = Configuration.GetConnectionString("DefaultConnection");
            using(var conn = new SqlConnection(connectionstring)) 
            {
                conn.Open();
                string commandText = "select MessageText from dbo.TbMessages";
                using (var cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Notification = null;
                    SqlDependency dependency = new SqlDependency(cmd);
                    dependency.OnChange += persona_onchange;
                    SqlDependency.Start(connectionstring);
                    //cmd.ExecuteReader();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) {
                            var p = new TbMessage
                            {
                                MessageText = reader["MessageText"].ToString()
                            };


                        }
                    }
                }
            }
            
        }
        private void persona_onchange (object sender , SqlNotificationEventArgs e) 
        
        {
            if(e.Type == SqlNotificationType.Change) 
            {
                string menj = obtm(e);
                ChatHub.Clients.All.SendAsync("receiveMessage");
                subscrippersonal();
            }
        }
        private string obtm (SqlNotificationEventArgs e) 
        {
            switch(e.Info) 
            {
                case SqlNotificationInfo.Insert:
                    return "insert";
                case SqlNotificationInfo.Delete:
                    return "delete";
                case SqlNotificationInfo.Update:
                    return "update";
                default:
                    return "noting";
;
            }
        }
        public List<TbMessage> GetContacts( )
        {
            List<TbMessage> o = new List<TbMessage>();
            return Context.TbMessages.ToList();

        }

        private IDisposable SqlCommand(string v, string connectionstring)
        {
            throw new NotImplementedException();
        }
    }
}
