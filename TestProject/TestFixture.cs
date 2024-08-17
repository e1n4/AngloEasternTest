using AngloEasternBEChallenge.Models;

namespace TestProject
{
    public class TestFixture
    {
        public List<MdlShip> Ships { get; set; } = [];
        public List<MdlUser> Users { get; set; } = [];
        public List<MdlSeaPort> SeaPorts { get; set; } = [];

        public TestFixture()
        {
            InitializeData();
        }

        public void InitializeData()
        {
             Ships =
            [
                new() { ShipCode = "S03", ShipName = "Ship3", Longitude = 12.34, Latitude = 56.78, Velocity = 15.0 },
                new() { ShipCode = "S04", ShipName = "Ship4", Longitude = 34.56, Latitude = 78.90, Velocity = 25.0 },
            ];
            
            Users =
            [
                new MdlUser { UserCode="Admin1", UserName = "Admin One", Role = "Admin" },
                new MdlUser { UserCode="User1", UserName = "User One", Role = "User" },
            ];
         
            SeaPorts =
            [
                new MdlSeaPort { SeaPortCode = "HKHKG", SeaPortName = "Hong Kong", Longitude = 22.18, Latitude = 114.10 },
                new MdlSeaPort { SeaPortCode="IDLKS", SeaPortName = "Lombok Strait", Longitude = 8.34, Latitude = 115.44 },
                new MdlSeaPort { SeaPortCode="IDSST", SeaPortName = "Sunda Strait", Longitude = 5.28, Latitude = 106.00 },
            ];
        }
    }
}
