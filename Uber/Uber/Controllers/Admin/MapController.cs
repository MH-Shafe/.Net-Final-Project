using BLL.Services.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Uber.Controllers.Admin
{
    [RoutePrefix("api/admin")]
    public class MapController : ApiController
    {


        [HttpPost]
        [Route("distance")]
        public async Task<HttpResponseMessage> CalculateDistance([FromBody] DistanceRequest request)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var mapService = new MapService("f131728e-f313-49dd-93fc-94c4e9349859", "-bEtCkinJ1caUxy0ihSnKV_UMlGDZjizANjT2jfWjq8");

            double distance = await mapService.CalculateDistance(request.Origin, request.Destination);

            var response = new DistanceResponse { Distance = distance };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        public class DistanceRequest
        {
            public string Origin { get; set; }
            public string Destination { get; set; }
        }

        public class DistanceResponse
        {
            public double Distance { get; set; }
        }
    }
}
