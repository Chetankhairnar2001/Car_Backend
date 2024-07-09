using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarAuction_Backend.Models;

namespace CarAuction_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        CarAuctionDbContext dbContext = new CarAuctionDbContext();

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(dbContext.Bids);
        }

        [HttpGet("getbycarId")]
        public IActionResult GetByCarId(int carid)
        {
            return Ok(dbContext.Bids.Where(b => b.CarId == carid));
        }

        [HttpPost()]
        public IActionResult AddBid([FromBody] Bid newBid) {
            dbContext.Bids.Add(newBid);
            dbContext.SaveChanges();
            return Created($"Bids/Api/{newBid.Id}", newBid);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBid(int id) {
            Bid result = dbContext.Bids.Find(id);
            if (result == null) { 
                return NotFound();
            }
            dbContext.Bids.Remove(result);
            dbContext.SaveChanges();
            return NoContent();
        }

    }
}
