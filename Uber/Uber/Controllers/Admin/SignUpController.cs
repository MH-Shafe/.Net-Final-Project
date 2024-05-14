using BLL.DTOs.Admin;
using BLL.Services;
using BLL.Services.Admin;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Uber.Auth;

namespace Uber.Controllers.Admin
{
    public class SignUpController : ApiController
    {
        [HttpPost]
        [Route("api/signup/create")]
        public HttpResponseMessage Create(SignUpDTO signUpDTO)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            SignUpService.Create(signUpDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpGet]
        [Route("api/signup/{id}")]
        [AdminAuth]
        public HttpResponseMessage Get(int id)
        {
            var data = SignUpService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/signup/all")]
        [AdminAuth]
        public HttpResponseMessage GetAll()
        {
            var data = SignUpService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpDelete]
        [Route("api/signup/delete/{id}")]
        [AdminAuth]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                SignUpService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's requirements
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while deleting the sign-up.");
            }
        }

    }
}
