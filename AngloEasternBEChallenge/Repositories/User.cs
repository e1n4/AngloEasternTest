using AngloEasternBEChallenge.Interfaces;
using AngloEasternBEChallenge.Models;
using Microsoft.Extensions.Hosting;
using System.Linq;
using static AngloEasternBEChallenge.Repositories.Ship;

namespace AngloEasternBEChallenge.Repositories
{
    public class User : IUser
    {
        private List<MdlUser> _users;

        public User()
        {
            _users =
            [
                new MdlUser { UserCode="Admin1", UserName = "Admin One", Role = "Admin" },
                new MdlUser { UserCode="User1", UserName = "User One", Role = "User" },
            ];
        }

        public Task<List<MdlUser>> GetAllUsers()
        {
            return Task.FromResult(_users);
        }

        public Task<MdlUser?> GetUser(string userCode)
        {
            return Task.FromResult(_users.FirstOrDefault(x => x.UserCode == userCode));
        }

        public Task<StatusReport> CreateUser(MdlUser item)
        {
            var result = new StatusReport(true, "User Added.");
            if (!_users.Any(x => x.UserCode == item.UserCode))
                _users.Add(item);
            else
                result = new StatusReport(false, "Duplicate User.");
            return Task.FromResult(result);
        }
    }
}
