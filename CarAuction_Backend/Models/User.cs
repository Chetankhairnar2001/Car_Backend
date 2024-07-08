using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CarAuction_Backend.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? StreetAddress { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Email { get; set; }

    [JsonIgnore]

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();
	[JsonIgnore]
	public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
	[JsonIgnore]
	public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
