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
    public class FireController : ApiController
    {
        [Route("api/fires")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = FireService.GetFire();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/fires/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = FireService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/fires/add")]
        [HttpPost]
        public HttpResponseMessage Post(FireDTO Fire)
        {
            var resp = FireService.Add(Fire);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
