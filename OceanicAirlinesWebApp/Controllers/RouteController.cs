using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlinesWebApp.Models;

namespace OceanicAirlinesWebApp.Controllers
{
    [Route("api/route")]
    [ApiController]
    public class RouteController : ControllerBase { 

        public ResultDTO GetRoute(RequestDTO request)
        {
            return new ResultDTO()
            {
                Price = 0,
                Time = 0
            };
        }

    }
}
