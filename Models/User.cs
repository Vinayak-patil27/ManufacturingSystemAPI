using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class User
{
    public int SrNo { get; set; }

    public string? Name { get; set; }

    public string UserId { get; set; } = null!;

    public string Password { get; set; } = null!;
}
