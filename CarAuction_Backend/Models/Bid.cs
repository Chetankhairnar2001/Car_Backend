using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CarAuction_Backend.Models;

public partial class Bid
{
    public int Id { get; set; }

    public int? CarId { get; set; }

    public int? BuyerId { get; set; }

    public double? BidAmmount { get; set; }

    public DateTime? Timestamp { get; set; }

    [JsonIgnore]
    public virtual User? Buyer { get; set; }

    [JsonIgnore]
    public virtual Car? Car { get; set; }
}
