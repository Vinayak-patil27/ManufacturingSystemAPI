using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Location
{
    public long LocationId { get; set; }

    public string? LocationName { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}
