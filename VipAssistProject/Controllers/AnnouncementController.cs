using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VipAssistProject.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Hubs;
using VipAssistProject.Models;
namespace VipAssistProject.Controllers
{
    public class AnnouncementController : Controller
    {
        private IHubContext<ChatHub> _hubcontext;
        public AnnouncementController(IHubContext<ChatHub> hubcontext) 
        {
            _hubcontext = hubcontext;
        }
        [HttpGet("/announcement")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("/announcement")]
        public async Task <IActionResult> Post([FromForm] TbMessage message)
        {
            
            await _hubcontext.Clients.All.SendAsync("receiveMessage", message);
            return RedirectToAction("Index");
        }
    }
}
