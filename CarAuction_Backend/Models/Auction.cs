using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CarAuction_Backend.Models;

public partial class Auction
{
    public int Id { get; set; }

    public int? CarId { get; set; }

    public int? SellerId { get; set; }

    public double? StartingBid { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    [JsonIgnore]
    public virtual User? Buyer { get; set; }

    [JsonIgnore]
    public virtual Car? Car { get; set; }

    [JsonIgnore]
    public virtual User? Seller { get; set; }
}
