using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class AspNetUserClaim
{
    public int Id { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public string UserId { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
