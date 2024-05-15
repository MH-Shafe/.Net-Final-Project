using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs.Admin;
using BLL.Services.Admin;

namespace Uber.Controllers.Admin
{
    [RoutePrefix("api/passwordchange")]
    public class PasswordChangeController : ApiController
    {
        private readonly PasswordChangeService _passwordChangeService;

        public PasswordChangeController(PasswordChangeService passwordChangeService)
        {
            _passwordChangeService = passwordChangeService;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var passwordChanges = _passwordChangeService.GetAll();
                return Ok(passwordChanges);
            }
            catch (Exception ex)
            {
                // Log the exception or return a more specific error message
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(PasswordChangeDTO passwordChangeDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _passwordChangeService.Create(passwordChangeDTO);
                return Ok("Password change request successful");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // You can add more actions here as needed
    }
}
