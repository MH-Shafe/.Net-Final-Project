using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.DTOs.Admin;
using BLL.Services.Admin;

namespace Uber.Controllers.Admin
{
    [RoutePrefix("api/admin/users")]
    public class ManageUsersController : ApiController
    {
        private readonly ManageUsersService _userService;

        public ManageUsersController(ManageUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{userId}")]
        public HttpResponseMessage GetUser(int userId)
        {
            try
            {
                var user = _userService.GetUser(userId);
                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateUser(SignUpDTO userDTO)
        {
            try
            {
                _userService.CreateUser(userDTO);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("{userId}")]
        public HttpResponseMessage UpdateUser(int userId, SignUpDTO userDTO)
        {
            try
            {
                _userService.UpdateUser(userId, userDTO);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{userId}")]
        public HttpResponseMessage DeleteUser(int userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Request.CreateResponse(HttpStatusCode.NoContent, new { Message = userId + " User details has been Deleted." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        // Methods for managing login details
        // Implement the necessary actions for managing login details here
    }
}
