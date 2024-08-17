using AngloEasternBEChallenge.Interfaces;
using AngloEasternBEChallenge.Models;

namespace AngloEasternBEChallenge.Repositories
{
    public class SeaPort : ISeaPort
    {
        private readonly List<MdlSeaPort> _ports;

        public SeaPort()
        {
            _ports =
            [
                new MdlSeaPort { SeaPortCode = "HKHKG", SeaPortName = "Hong Kong", Longitude = 22.18, Latitude = 114.10 },
                new MdlSeaPort { SeaPortCode="IDLKS", SeaPortName = "Lombok Strait", Longitude = 8.34, Latitude = 115.44 },
                new MdlSeaPort { SeaPortCode="IDSST", SeaPortName = "Sunda Strait", Longitude = 5.28, Latitude = 106.00 },
            ];
        }

        public Task<List<MdlSeaPort>> GetAllSeaPorts()
        {
            return Task.FromResult(_ports);
        }
    }
}
