using System.ComponentModel.DataAnnotations;

namespace AngloEasternBEChallenge.Models
{
    public class MdlShip
    {
        [Key] public required string ShipCode { get; set; }
        public string ShipName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Velocity { get; set; }
        public string UserCode { get; set; }
        public DateTime EstimatedArrivalTime { get; set; }
    }
}
