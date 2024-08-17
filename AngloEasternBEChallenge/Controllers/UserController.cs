using AngloEasternBEChallenge.Interfaces;
using AngloEasternBEChallenge.Models;
using AngloEasternBEChallenge.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AngloEasternBEChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _users;

        public UserController()
        {
            _users = new User();
        }

        [HttpGet]
        public async Task<ActionResult<List<MdlUser>>> GetAllUsers()
        {
            var posts = await _users.GetAllUsers();
            return Ok(posts);
        }

        [HttpGet("{code}")] 
        public async Task<ActionResult<MdlUser>> GetUser(string code)
        {
            var posts = await _users.GetUser(code);
            return Ok(posts);
        }

        [HttpPost] 
        public async Task<ActionResult<MdlUser>> CreateUser(MdlUser item)
        {
            var posts = await _users.CreateUser(item);
            return Ok(posts);
        }
    }
}
