using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emergency_Dispatcher_Service.Controllers
{
    public class PoliceController : ApiController
    {
        [Route("api/polices")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = PoliceService.GetPolice();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/polices/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = PoliceService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/polices/add")]
        [HttpPost]
        public HttpResponseMessage Add(PoliceDTO police)
        {
            if (ModelState.IsValid)
            {
                var data = PoliceService.Add(police);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }
    }
}
