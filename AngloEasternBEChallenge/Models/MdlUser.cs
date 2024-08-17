using System.ComponentModel.DataAnnotations;

namespace AngloEasternBEChallenge.Models
{
    public class MdlUser
    {
        [Key] public required string UserCode { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string[] ShipCodes { get; set; }
    }
}
