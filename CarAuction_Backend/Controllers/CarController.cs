using CarAuction_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarAuction_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        CarAuctionDbContext dbContext = new CarAuctionDbContext();

        [HttpGet()]
        public IActionResult GetAllCar(string make,string model,short year)
        {
            return Ok(CarDal.getCars(make,model,year));
        }   


    }
}
