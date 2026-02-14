using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;
}
