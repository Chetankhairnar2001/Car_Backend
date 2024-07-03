using System;
using System.Collections.Generic;

namespace CarAuction_Backend.Models;

public partial class Auction
{
    public int Id { get; set; }

    public int? CarId { get; set; }

    public int? BuyerId { get; set; }

    public int? SellerId { get; set; }

    public double? StartingBid { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual User? Buyer { get; set; }

    public virtual Car? Car { get; set; }

    public virtual User? Seller { get; set; }
}
