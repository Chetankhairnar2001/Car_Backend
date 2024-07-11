using CarAuction_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarAuction_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        CarAuctionDbContext dbContext = new CarAuctionDbContext();

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(dbContext.Users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User result = dbContext.Users.Find(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("getUserById")]
        public IActionResult GetUserById(int id) {
            User result = dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if(dbContext.Users.Any(u => u.Email.ToLower() == user.Email.ToLower()))
            {
                return Ok(dbContext.Users.FirstOrDefault(u => u.Email.ToLower() == user.Email.ToLower()));
            }
            else
            {
                user.Id = 0;
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return Created($"User/Api/{user.Id}", user);
            }
        }

   
		[HttpGet("getIdByEmail")]

		public IActionResult getIdByEmail(string email) {
                    
            User result = dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (result == null) {return NotFound();}
            return Ok(result.Id);
        }


    }
}
