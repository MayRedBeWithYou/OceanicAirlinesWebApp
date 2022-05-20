using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlinesWebApp.Algorithms;
using OceanicAirlinesWebApp.Models;

namespace OceanicAirlinesWebApp.Controllers
{
    [Route("api/route")]
    [ApiController]
    public class RouteController : ControllerBase
    {

        public ResultDTO GetRoute(RequestDTO request)
        {
            Graph graph = new Graph();
            var result = graph.Dijkstra(
                graph.Nodes.Find(node => node.Name.ToLower() == request.From.ToLower()).Id,
                graph.Nodes.Find(node => node.Name.ToLower() == request.To.ToLower()).Id, e => e.Time);
            result.CalculatePriceAndTime(new Parcel()
            {
                Category = request.Type,
                Weight = request.Weight,
                Height = request.Height,
                Width = request.Width,
                Length = request.Length,
            });
            return new ResultDTO()
            {
                Price = result.TotalPrice,
                Time = result.TotalTime
            };
        }

    }
}
