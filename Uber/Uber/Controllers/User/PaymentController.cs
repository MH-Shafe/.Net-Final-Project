using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs.User;
using BLL.Services.User;

namespace Uber.Controllers.User
{
    [RoutePrefix("api/payment")]
    public class PaymentController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetPayments()
        {
            try
            {
                var payments = PaymentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, payments);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetPayment(int id)
        {
            try
            {
                var payment = PaymentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, payment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreatePayment(PaymentDTO paymentDTO)
        {
            try
            {
                PaymentService.Create(paymentDTO);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
