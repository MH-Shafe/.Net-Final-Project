using BLL.DTOs.Admin;
using BLL.Services.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Uber.Auth;

namespace Uber.Controllers.Admin
{
    [RoutePrefix("api/admin/driverinfo")]
    public class DriverInfoController : ApiController
    {        

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = DriverInfoService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(DriverInfoDTO driverInfoDTO)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            DriverInfoService.Create(driverInfoDTO);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = driverInfoDTO+ " driverInfo Add successful" });
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            var data = DriverInfoService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        [AdminAuth]
        public IHttpActionResult DeleteDriverInfo(int id)
        {
            try
            {
                // Call the delete service method
                DriverInfoService.Delete(id);
                return Ok(id + " DriverInfo deleted successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
