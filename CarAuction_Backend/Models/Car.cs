using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CarAuction_Backend.Models;

public partial class Car
{
    public int Id { get; set; }

    public int? SellerId { get; set; }

    public double? City_Mpg { get; set; }

    public string? Class { get; set; }

    public double? Combination_Mpg { get; set; }

    public short? Cylinders { get; set; }

    public double? Displacement { get; set; }

    public string? Drive { get; set; }

    public string? Fuel_Type { get; set; }

    public double? Highway_Mpg { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? Transmission { get; set; }

    public short? Year { get; set; }

    [JsonIgnore]
    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    [JsonIgnore]
    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    [JsonIgnore]
    public virtual User? Seller { get; set; }
}
