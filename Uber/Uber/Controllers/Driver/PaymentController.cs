using BLL.DTOs.User;
using BLL.Services.User;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Uber.Controllers.User
{
    [RoutePrefix("api/payment")]
    public class PaymentController : ApiController
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetPayments()
        {
            try
            {
                var payments = _paymentService.GetAllPayments();
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
                var payment = _paymentService.GetPayment(id);
                if (payment == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Payment not found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, payment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreatePayment([FromBody] PaymentDTO paymentDTO)
        {
            try
            {
                _paymentService.CreatePayment(paymentDTO);
                return Request.CreateResponse(HttpStatusCode.Created, new { Message = "Payment created successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage UpdatePayment(int id, [FromBody] PaymentDTO paymentDTO)
        {
            try
            {
                paymentDTO.PaymentID = id;
                _paymentService.UpdatePayment(paymentDTO);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Payment updated successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeletePayment(int id)
        {
            try
            {
                _paymentService.DeletePayment(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Payment deleted successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
