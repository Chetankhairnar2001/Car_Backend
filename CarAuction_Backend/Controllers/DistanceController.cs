using CarAuction_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarAuction_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DistanceController : ControllerBase
	{
		[HttpGet()]
		public IActionResult getDistance(int zip1, int zip2)
		{
			return Ok(ZipCodeDAL.getDistance(zip1, zip2));
		}
	}
}
