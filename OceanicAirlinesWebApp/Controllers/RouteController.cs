using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlinesWebApp.Algorithms;
using OceanicAirlinesWebApp.Data;
using OceanicAirlinesWebApp.Models;

namespace OceanicAirlinesWebApp.Controllers
{
    [Route("api/route")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private OceanicAirlinesWebAppContext _context;

        public RouteController(OceanicAirlinesWebAppContext context)
        {
            _context = context;
        }

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
        [HttpPost]
        public ResultDTO OrderParcel(OrderRequestDTO request)
        {
            Graph graph = new Graph();
            var result = graph.Dijkstra(
                graph.Nodes.Find(node => node.Name.ToLower() == request.From.ToLower()).Id,
                graph.Nodes.Find(node => node.Name.ToLower() == request.To.ToLower()).Id, e => e.Time);
            var parcel = new Parcel()
            {
                Category = request.Type,
                From = request.From,
                To = request.To,
                Weight = request.Weight,
                Height = request.Height,
                Width = request.Width,
                Length = request.Length,
                Name = request.Name,
                Email = request.Email,
            };
            result.CalculatePriceAndTime(parcel);
            parcel.Price = result.TotalPrice;
            parcel.Size = parcel.CalculatedSize;
            parcel.Time = result.TotalTime;
            _context.Parcel.Add(parcel);
            _context.SaveChanges();
            Invoice invoice = new Invoice();
            invoice.sendEmail("1231", parcel.Name, parcel.Email, parcel.Price.ToString(), parcel.Time.ToString(), parcel.From, parcel.To);
            return new ResultDTO()
            {
                Price = parcel.Price,
                Time = parcel.Time
            };
        }

    }
}
