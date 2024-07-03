using System;
using System.Collections.Generic;

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

    public virtual ICollection<Auction> AuctionBuyers { get; set; } = new List<Auction>();

    public virtual ICollection<Auction> AuctionSellers { get; set; } = new List<Auction>();

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
