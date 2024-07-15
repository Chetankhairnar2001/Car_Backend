using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace CarAuction_Backend.Models;

public partial class Car
{
	public int Id { get; set; }

	public int? SellerId { get; set; }

	public double? CityMpg { get; set; }

	public string? Class { get; set; }

	public double? CombinationMpg { get; set; }

	public short? Cylinders { get; set; }

	public double? Displacement { get; set; }

	public string? Drive { get; set; }

	public string? FuelType { get; set; }

	public double? HighwayMpg { get; set; }

	public string? Make { get; set; }

	public string? Model { get; set; }

	public string? Transmission { get; set; }

	public short? Year { get; set; }

	public string? Color { get; set; }

	public int? Mileage { get; set; }

	public string? Image { get; set; }
	[JsonIgnore]
	public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();
	[JsonIgnore]
	public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
	[JsonIgnore]
	public virtual User? Seller { get; set; }
}



public class CarApi
{
	public int city_mpg { get; set; }
    public int SellerId { get; set; }//newly added
    public string Class { get; set; }
	public int combination_mpg { get; set; }
	public short cylinders { get; set; }
	public float displacement { get; set; }
	public string drive { get; set; }
	public string fuel_type { get; set; }
	public int highway_mpg { get; set; }
	public string make { get; set; }
	public string model { get; set; }
	public string transmission { get; set; }
	public short year { get; set; }
}

