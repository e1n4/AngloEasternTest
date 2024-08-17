using AngloEasternBEChallenge.Interfaces;
using AngloEasternBEChallenge.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;

namespace AngloEasternBEChallenge.Repositories
{
    public class Ship : IShip
    {
        private static readonly List<MdlShip> _ships =new()
        { 
            new() { ShipCode = "S01", ShipName = "Ship1", Longitude = 12.34, Latitude = 56.78, Velocity = 10.0 },
            new() { ShipCode = "S02", ShipName = "Ship2", Longitude = 34.56, Latitude = 78.90, Velocity = 20.0 },
        };

        public Task<List<MdlShip>> GetAllShips()
        {
            return Task.FromResult(_ships);
        }

        public Task<List<MdlShip>> GetAssignedShips(string userCode)
        {
            return Task.FromResult(_ships.Where(x => x.UserCode != null && x.UserCode != "" &&  x.UserCode == userCode).ToList());
        }

        public Task<List<MdlShip>> GetUnassignedShips()
        {
            return Task.FromResult(_ships.Where(x => x.UserCode == null || x.UserCode == "").ToList());
        }

        public Task<MdlShip?> GetShip(string pShipCode)
        {
            return Task.FromResult(_ships.FirstOrDefault(x => x.ShipCode == pShipCode));
        }

        public Task<StatusReport> CreateShip(MdlShip item)
        {
            var result = new StatusReport(true, "Data Appended.");
            if (!_ships.Any(x => x.ShipCode == item.ShipCode))
                _ships.Add(item);
            else
                result = new StatusReport(false, "Duplicate Data.");
            return Task.FromResult(result);
        }

        public async Task<MdlShip?> UpdateAssignedShip(string shipCode, string userCode)
        {
            var ship = _ships.FirstOrDefault(x => x.ShipCode == shipCode);
            var user = await new User().GetUser(userCode);
            if (ship != null && user != null)
                ship.UserCode = userCode;
            else
                ship = null;

            return await Task.FromResult(ship);
        }

        public Task<MdlShip?> UpdateShipVelocity(string shipCode, double velocity)
        {
            var ship = _ships.FirstOrDefault(x => x.ShipCode == shipCode);
            if (ship != null)
                ship.Velocity = velocity;

            return Task.FromResult(ship);
        }

        public class StatusReport(bool ok, string msg)
        {
            public bool Ok { get; set; } = ok;
            public string Msg { get; set; } = msg;
        }
    }
}
