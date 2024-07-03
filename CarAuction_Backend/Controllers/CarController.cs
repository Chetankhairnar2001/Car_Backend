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
        public IActionResult GetCars(string make,string model,short year)
        {
            return Ok(CarDal.getCars(make,model,year));
        }

        [HttpGet("test")]
        public IActionResult GetAllCars()
        {
            return Ok(dbContext.Cars);
        }

        [HttpPost()]
        public IActionResult AddCar([FromBody] Car newCar, string color, int miles, string img)
        {
            newCar.Id = 0;
            newCar.Color = color;
            newCar.Mileage = miles;
            newCar.Image = img;

            dbContext.Cars.Add(newCar);
            dbContext.SaveChanges();
            return Created($"/Car/Api/{newCar.Id}", newCar);
        }

        [HttpDelete("id")]
        public IActionResult DeleteCar(int id)
        {
            Car result = dbContext.Cars.Find(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Cars.Remove(result);
                dbContext.SaveChanges();
                return NoContent();
            }
        }



    }
}
