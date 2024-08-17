using AngloEasternBEChallenge.Interfaces;
using AngloEasternBEChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngloEasternBEChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeaPortController(ISeaPort seaport, IShip ship) : ControllerBase
    {
        private readonly ISeaPort _seaport = seaport;
        private readonly IShip _ship = ship;

        [HttpGet]
        public async Task<ActionResult<List<MdlSeaPort>>> GetAllSeaPorts()
        {
            var posts = await _seaport.GetAllSeaPorts();
            return Ok(posts);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult> GetClosestPortAndEstimatedArrivalTime(string code)
        {
            var ship = await _ship.GetShip(code);
            if (ship == null)
                return NotFound();

            // Calculate the closest port
            var seaPorts = await _seaport.GetAllSeaPorts();
            var closestPort = seaPorts.OrderBy(p => CalculateDistance(ship.Latitude, ship.Longitude, p.Latitude, p.Longitude)).FirstOrDefault();

            if (closestPort == null)
                return NotFound();

            // Get the estimated arrival time at the closest port
            var estimatedArrivalTime = CalculateEstimatedArrivalTime(ship, closestPort.Latitude, closestPort.Longitude);
            ship.EstimatedArrivalTime = estimatedArrivalTime;

            return Ok(new StatusReport(closestPort.SeaPortName, estimatedArrivalTime));
        }

        private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Haversine formula
            var earthRadius = 6371; // kilometers

            var dLat = Math.PI * (lat2 - lat1) / 180;
            var dLon = Math.PI * (lon2 - lon1) / 180;

            var lat1Rad = Math.PI * lat1 / 180;
            var lat2Rad = Math.PI * lat2 / 180;

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1Rad) * Math.Cos(lat2Rad);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return earthRadius * c;
        }

        private static DateTime CalculateEstimatedArrivalTime(MdlShip ship, double latitude, double longitude)
        {
            var distanceToPort = CalculateDistance(ship.Latitude, ship.Longitude, latitude, longitude);
            var estimatedArrivalTime = distanceToPort / ship.Velocity;
            return DateTime.Now.AddHours(estimatedArrivalTime);
        }

        public class StatusReport(string seaPortName, DateTime estimatedTime)
        {
            public string SeaPortName { get; set; } = seaPortName;
            public DateTime EstimatedArrivalTime { get; set; } = estimatedTime;
        }
    }
}
