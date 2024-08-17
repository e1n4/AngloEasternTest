using AngloEasternBEChallenge.Models;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using static AngloEasternBEChallenge.Repositories.Ship;

namespace AngloEasternBEChallenge.Interfaces
{
    public interface IUser
    {
        Task<List<MdlUser>> GetAllUsers();
        Task<MdlUser?> GetUser(string code);
        Task<StatusReport> CreateUser(MdlUser item);
    }
}
