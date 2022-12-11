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
    public class BombController : ApiController
    {
        [Route("api/bombs")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = BombService.GetBomb();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/bombs/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = BombService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/bombs/add")]
        [HttpPost]
        public HttpResponseMessage Post(BombDTO Bomb)
        {
            var resp = BombService.Add(Bomb);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
