using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipAssistProject.Bl;
using VipAssistProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VipAssistProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesApiController : ControllerBase
    {
        VipAssistDatabaseContext Ctx;
        ISliderImagesServices SliderImagesServices;
        IServiceMediasServices ServiceMediasServices;
        IServicesServices ServicesServices;
        public ServicesApiController(IServicesServices servicesServices, VipAssistDatabaseContext ctx, ISliderImagesServices sliderImagesServices, IServiceMediasServices serviceMediasServices)
        {
            Ctx = ctx;
            SliderImagesServices = sliderImagesServices;
            ServiceMediasServices = serviceMediasServices;
            ServicesServices = servicesServices;

        }
        // GET: api/<ServicesApiController>
        [HttpGet]
        public IEnumerable<VwGetServiceList> Get()
        {
            return Ctx.VwGetServiceList.ToList();
        }

        // GET api/<ServicesApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ServicesApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServicesApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
