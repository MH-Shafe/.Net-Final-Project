using BLL.DTOs.User;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Uber.Controllers.User
{
 
    [RoutePrefix("api/user/subscriptions")]
    public class SubscriptionController : ApiController
    {
        [HttpGet]
        [Route("getall")]
        public HttpResponseMessage GetSubscriptions()
        {
            try
            {
                var subscriptions = SubscriptionService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, subscriptions);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetSubscription(int id)
        {
            try
            {
                var subscription = SubscriptionService.Get(id);
                if (subscription == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                return Request.CreateResponse(HttpStatusCode.OK, subscription);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateSubscription(SubscriptionDTO subscriptionDTO)
        {
            try
            {
                SubscriptionService.Create(subscriptionDTO);
                return Request.CreateResponse(HttpStatusCode.Created, new { Message = "createed" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage UpdateSubscription(int id, SubscriptionDTO subscriptionDTO)
        {
            try
            {
                // Ensure the ID in the DTO matches the ID in the route
                if (id != subscriptionDTO.SubscriptionID)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                SubscriptionService.Update(subscriptionDTO);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteSubscription(int id)
        {
            try
            {
                SubscriptionService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}