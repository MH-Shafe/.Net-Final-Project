using BLL.DTOs.Driver;
using BLL.Services.Driver;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Uber.Controllers.Driver
{
    [RoutePrefix("api/driver")]
    public class SubscriptionController : ApiController
    {
        private readonly SubscriptionService _subscriptionService;

        // Constructor injection
        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        public SubscriptionController()
        {
            // You can initialize any fields or properties here if needed
        }
        [HttpPost]
        [Route("CreateSubscription")]
        public IHttpActionResult CreateSubscription(Subscription subscription)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _subscriptionService.Create(subscription);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("GetAllSubscriptions")]
        public IHttpActionResult GetAllSubscriptions()
        {
            try
            {
                var subscriptions = _subscriptionService.Get();
                return Ok(subscriptions);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("GetSubscription/{id}")]
        public IHttpActionResult GetSubscription(int id)
        {
            try
            {
                var subscription = _subscriptionService.Get(id);
                if (subscription == null)
                {
                    return NotFound();
                }
                return Ok(subscription);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("UpdateSubscription")]
        public IHttpActionResult UpdateSubscription(Subscription subscription)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _subscriptionService.Update(subscription);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("DeleteSubscription/{id}")]
        public IHttpActionResult DeleteSubscription(int id)
        {
            try
            {
                _subscriptionService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
