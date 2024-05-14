using BLL.DTOs.Admin;
using BLL.DTOs.Driver;
using BLL.Services.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Uber.Controllers
{
    public class SignUp_DController : ApiController
    {
        // GET api/signup_d
        [HttpGet]
        [Route("api/signup_d")]
        public HttpResponseMessage GetSignUp_D()
        {
            try
            {
                var data = SignUpService_D.GetSignUps();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        // GET api/signup_d/5
        [HttpGet]
        [Route("api/signup_d/{id}")]
        public HttpResponseMessage GetSignUp_D(int id)
        {
            try
            {
                var data = SignUpService_D.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        // POST api/signup_d
        [HttpPost]
        [Route("api/signup_d")]
        public HttpResponseMessage PostSignUp_D([FromBody] SignUpDTO_D signUpDto)
        {
            try
            {
                SignUpService_D.CreateSignUp(signUpDto);
                return Request.CreateResponse(HttpStatusCode.Created, new { Message = "SignUp_D created successfully." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        // POST api/signup_d/login
        [HttpPost]
        [Route("api/signup_d/login")]
        public HttpResponseMessage PostSignUpAndLogin([FromBody] SignUpLoginDTO signUpLoginDto)
        {
            try
            {
                SignUpService_D.CreateSignUpAndLogin(signUpLoginDto);
                return Request.CreateResponse(HttpStatusCode.Created, new { Message = "SignUp_D and Login created successfully." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
