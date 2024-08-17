using System.ComponentModel.DataAnnotations;

namespace AngloEasternBEChallenge.Models
{
    public class MdlSeaPort
    {
        [Key] public required string SeaPortCode { get; set; }
        public string SeaPortName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
