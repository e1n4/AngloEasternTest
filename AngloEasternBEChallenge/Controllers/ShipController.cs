using AngloEasternBEChallenge.Models;
using AngloEasternBEChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using static AngloEasternBEChallenge.Repositories.Ship;

namespace AngloEasternBEChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipController : ControllerBase
    {
        private readonly Ship _ships;

        public ShipController()
        {
            _ships = new Ship();
        }

        [HttpGet]
        public async Task<ActionResult<List<MdlShip>>> GetAllShips()
        {
            var posts = await _ships.GetAllShips();
            return Ok(posts);
        }

        [HttpGet("user/{userCode}")]
        public async Task<ActionResult<MdlShip>> GetAssignedShips(string userCode)
        {
            var posts = await _ships.GetAssignedShips(userCode);
            return Ok(posts);
        }

        [HttpGet("unassigned")]
        public async Task<ActionResult<List<MdlShip>>> GetUnassignedShips()
        {
            var posts = await _ships.GetUnassignedShips();
            return Ok(posts);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<MdlShip>> GetShip(string code)
        {
            var posts = await _ships.GetShip(code);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult<StatusReport>> CreateShip(MdlShip item)
        {
            var posts = await _ships.CreateShip(item);
            return Ok(posts);
        }

        [HttpPut("{shipCode}/{userCode}")]
        public async Task<ActionResult<MdlShip>> UpdateAssignedShip([FromRoute] string shipCode, [FromRoute] string userCode)
        {
            var updatedPost = await _ships.UpdateAssignedShip(shipCode, userCode);
            if (updatedPost == null)
            {
                return BadRequest();
            }

            return Ok(updatedPost);
        }

        [HttpPut("{code}")]
        public async Task<ActionResult<MdlShip>> UpdateShipVelocity(string code, double velocity)
        {
            var updatedPost = await _ships.UpdateShipVelocity(code, velocity);
            if (updatedPost == null)
            {
                return NotFound();
            }

            return Ok(updatedPost);
        }
    }
}
