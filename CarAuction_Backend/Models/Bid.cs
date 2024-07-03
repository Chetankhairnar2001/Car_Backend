using System;
using System.Collections.Generic;

namespace CarAuction_Backend.Models;

public partial class Bid
{
    public int Id { get; set; }

    public int? CarId { get; set; }

    public int? BuyerId { get; set; }

    public double? BidAmmount { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual User? Buyer { get; set; }

    public virtual Car? Car { get; set; }
}
