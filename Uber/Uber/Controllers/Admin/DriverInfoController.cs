using BLL.DTOs.Admin;
using BLL.Services.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Uber.Controllers.Admin
{
    [RoutePrefix("api/admin")]
    public class DriverInfoController : ApiController
    {        

        [HttpGet]
        [Route("driverinfo/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = DriverInfoService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("driverinfo/create")]
        public HttpResponseMessage Create(DriverInfoDTO driverInfoDTO)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            DriverInfoService.Create(driverInfoDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("driverinfo/all")]
        public HttpResponseMessage GetAll()
        {
            var data = DriverInfoService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
