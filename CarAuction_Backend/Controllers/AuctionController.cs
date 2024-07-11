using CarAuction_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarAuction_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        CarAuctionDbContext dbContext = new CarAuctionDbContext();

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(dbContext.Auctions.Include(a=>a.Car).OrderBy(a=>a.EndTime));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            Auction result = dbContext.Auctions.Include(a => a.Car).FirstOrDefault(a=>a.Id == id);
            if (result == null) {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost()]
		//int carId, int sellerId, double startingBid, DateTime startTime, DateTime endTime
		public IActionResult AddAuction([FromBody] Auction newAuction)
        {
            newAuction.Id = 0;
            dbContext.Auctions.Add(newAuction);
            dbContext.SaveChanges();
            return Created($"/Auction/Api/{newAuction.Id}", newAuction);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuction(int id)
        {
            Auction result = dbContext.Auctions.Find(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Auctions.Remove(result);
                dbContext.SaveChanges();
                return NoContent();
            }
        }
    }
}
