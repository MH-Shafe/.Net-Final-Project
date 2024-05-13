using BLL.DTOs.Admin;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Uber.Controllers.Admin
{
    [RoutePrefix("api/signup")]
    public class SignUpController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetSignUp()
        {
            try
            {
                var data = SignUpService.GetSignUps();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetSignUp(int id)
        {
            try
            {
                var data = SignUpService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateSignUp(SignUpDTO signUpDTO)
        {
            try
            {
                SignUpService.CreateSignUp(signUpDTO);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateSignUpLogin(SignUpLoginDTO signUpLoginDTO) // Corrected parameter type
        {
            try
            {
                SignUpService.CreateSignUpAndLogin(signUpLoginDTO); // Fixed method call
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        // You can add more actions as needed
    }
}
