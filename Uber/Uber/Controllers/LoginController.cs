using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Uber.Controllers
{
    [RoutePrefix("api/alllogin")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Logins()
        {
            try
            {
                var data = LoginService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        // POST api/login by create service
        /*
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login([FromBody] LoginDTO request)
        {
            try
            {
                LoginService.Create(request);
                return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Login created successfully." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }
        */



        /*
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login([FromBody] LoginDTO login)
        {
            try
            {
                var user = LoginService.GetByUsernameAndPassword(login.username, login.password);

                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "Invalid username or password" });
                }

                // Set the user's role in a cookie
                var cookie = new HttpCookie("UserRole");
                cookie.Value = user.roll;
                cookie.Expires = DateTime.Now.AddMinutes(5); // Cookie expires in 5 minutes
                HttpContext.Current.Response.Cookies.Add(cookie);

                // Login successful message
                var response = Request.CreateResponse(HttpStatusCode.OK, new { Message = "Login successful" });

                // Retrieve role from cookie and append it to the response message
                var userRole = HttpContext.Current.Request.Cookies["UserRole"]?.Value;
                if (!string.IsNullOrEmpty(userRole))
                {
                    response.Content = new StringContent(response.Content.ReadAsStringAsync().Result + " - User Role: " + userRole);
                }

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        */
    
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Authenticate([FromBody] LoginDTO login)
        {
            try
            {
                // Attempt to authenticate the user
                var user = LoginService.GetByUsernameAndPassword(login.username, login.password);

                if (user == null)
                {
                    // User not found or password incorrect
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "Invalid username or password" });
                }

                // Set the user's role in a cookie
                var cookie = new HttpCookie("UserRole");
                cookie.Value = user.roll;
                var UserNamecookie = new HttpCookie("username");
                UserNamecookie.Value = user.username;
                UserNamecookie.Expires = DateTime.Now.AddMinutes(5);
                cookie.Expires = DateTime.Now.AddMinutes(5); // Cookie expires in 5 minutes
                HttpContext.Current.Response.Cookies.Add(UserNamecookie);
                HttpContext.Current.Response.Cookies.Add(cookie);

                // Login successful message
                var response = Request.CreateResponse(HttpStatusCode.OK, new { Message = "Login successful" });

                // Retrieve role from cookie and append it to the response message
                var userRole = HttpContext.Current.Request.Cookies["UserRole"]?.Value;
                if (!string.IsNullOrEmpty(userRole))
                {
                    response.Content = new StringContent(response.Content.ReadAsStringAsync().Result + " - User Role: " + userRole);
                }

                return response;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.ToString());

                // Return a detailed error message
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An error occurred during authentication. Please try again later." });
            }
        }

        [HttpDelete]
        [Route("deleteAll/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                LoginService.DeleteUserData(id);
                return Request.CreateResponse(HttpStatusCode.OK,new { Message = id + " All info has been deleted" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's requirements
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "An error occurred while deleting user data.");
            }
        }
    }
}