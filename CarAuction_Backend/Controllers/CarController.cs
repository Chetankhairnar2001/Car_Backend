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
        public IActionResult AddCar([FromBody] CarApi newCar, string color, int miles, string img)
        {
            Car car = new Car();


            car.CityMpg = newCar.city_mpg;
            car.Class = newCar.Class;
            car.CombinationMpg = newCar.combination_mpg;
            car.Cylinders = newCar.cylinders;
            car.Displacement = newCar.displacement;
            car.Drive = newCar.drive;
            car.FuelType = newCar.fuel_type;
            car.HighwayMpg = newCar.highway_mpg;
            car.Make = newCar.make;
            car.Model = newCar.model;
            car.Transmission = newCar.transmission;
            car.Year = newCar.year; 

	
            car.Color = color;
            car.Mileage = miles;
            car.Image = img;

            dbContext.Cars.Add(car);
            dbContext.SaveChanges();
            return Created($"/Car/Api/{car.Id}", car);
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
