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
    public class CoastController : ApiController
    {
        [Route("api/coasts")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = CoastService.GetCoast();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/coasts/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = CoastService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/coasts/add")]
        [HttpPost]
        public HttpResponseMessage Post(CoastDTO Coast)
        {
            var resp = CoastService.Add(Coast);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
