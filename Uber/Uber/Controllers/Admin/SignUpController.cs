using BLL.DTOs.Admin;
using BLL.Services;
using BLL.Services.Admin;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;
using Uber.Auth;

namespace Uber.Controllers.Admin
{
    [RoutePrefix("api/signup")]
    public class SignUpController : ApiController
    {
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(SignUpDTO signUpDTO)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            SignUpService.Create(signUpDTO);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "SignUp successful" });
        }

        [HttpPut]
        [Route("update/{id}")]
        public IHttpActionResult Update(int id, SignUpDTO dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return BadRequest("ID mismatch between URL and object.");
                }
                var existingSignUp = SignUpService.Get(id);
                if (existingSignUp == null)
                {
                    return NotFound();
                }

                // Update SignUp
                SignUpService.Update(dto);
                return Ok(new { Message = "Update successful" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("An error occurred while updating the sign-up."));
            }
        }

    



        [HttpGet]
        [Route("{id}")]
        [AdminAuth]
        public HttpResponseMessage Get(int id)
        {
            var data = SignUpService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("all")]
     
        public HttpResponseMessage GetAll()
        {
            var data = SignUpService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        [AdminAuth]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                SignUpService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK,  new { Message =id+ " delete successful" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while deleting the sign-up.");
            }
        }
        [HttpDelete]
        [Route("deleteSignUpLogin/{id}")]
        [AdminAuth]
        public HttpResponseMessage DeleteSignupLogin(int id)
        {
            try
            {
                SignUpService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = id + " delete successful" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while deleting the sign-up.");
            }
        }

    }
}
