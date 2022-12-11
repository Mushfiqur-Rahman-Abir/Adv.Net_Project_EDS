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
    public class HospitalController : ApiController
    {
        [Route("api/hospitals")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = HospitalService.GetHospital();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/hospitals/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = HospitalService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/hospitals/add")]
        [HttpPost]
        public HttpResponseMessage Add(HospitalDTO hospital)
        {
            if (ModelState.IsValid)
            {
                var data = HospitalService.Add(hospital);
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
