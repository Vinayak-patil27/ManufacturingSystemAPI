using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class ComponentMaster
{
    public long ComponentId { get; set; }

    public long? CustomerId { get; set; }

    public string? ComponentName { get; set; }

    public string? PartNo { get; set; }

    public string? ENC { get; set; }
}
