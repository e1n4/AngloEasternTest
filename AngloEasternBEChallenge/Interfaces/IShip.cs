using AngloEasternBEChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using static AngloEasternBEChallenge.Repositories.Ship;

namespace AngloEasternBEChallenge.Interfaces
{
    public interface IShip
    {
        Task<List<MdlShip>> GetAllShips();
        Task<List<MdlShip>> GetAssignedShips(string userCode);
        Task<List<MdlShip>> GetUnassignedShips();
        Task<MdlShip?> GetShip(string code);
        Task<StatusReport> CreateShip(MdlShip item);
        Task<MdlShip?> UpdateAssignedShip([FromRoute] string shipCode, [FromRoute] string userCode);
        Task<MdlShip?> UpdateShipVelocity(string code, double velocity);
    }
}
