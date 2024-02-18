
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VipAssistProject.Hubs;
using VipAssistProject.Models;

using Microsoft.Data.SqlClient;



using System.Threading.Tasks;

namespace VipAssistProject
{
    public class NotificationCopmonent
    {
        private readonly IConfiguration Configuration;
        private readonly IHubContext<ChatHub> ChatHub;
        private readonly VipAssistDatabaseContext Context;
        public NotificationCopmonent()
        {
          
        }
        public NotificationCopmonent(VipAssistDatabaseContext context, object context2, object context1, IConfiguration configuration, IHubContext<ChatHub> chatHub)
        {
            Configuration = configuration;

            ChatHub = chatHub;
            Context = context;
        }
        public void RegisterNotification(DateTime currenttime)
        {
            string connectionstring = Configuration.GetConnectionString("DefaultConnection");
            using (var conn = new SqlConnection(connectionstring))
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

                    }
                }
            }
            
            
        }
        
        void persona_onchange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange += persona_onchange;
                ChatHub.Clients.All.SendAsync("added");
                RegisterNotification(DateTime.Now);
            }
        }

        public List<TbMessage> GetContacts(DateTime afterdate) 
        {
         
                return Context.TbMessages.ToList();
            
        }
    }
}