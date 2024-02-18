using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Models;
namespace VipAssistProject.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Messages message) =>
          await Clients.All.SendAsync("receiveMessage", message);

        public async Task SendMessageToCaller(Messages message)
        {
            await Clients.Caller.SendAsync("receiveMessage", message);
        }
        public async Task SendMessageToUser(string connectionId, Messages message)
        {
            await Clients.Client(connectionId).SendAsync("receiveMessage", message);
        }

        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendMessageToGroup(string group, Messages message)
        {
            await Clients.Group(group).SendAsync("receiveMessage", message);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(ex);
        }
    }
}
