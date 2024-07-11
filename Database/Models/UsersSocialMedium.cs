using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class UsersSocialMedium
{
    public int Id { get; set; }

    public int FkUserId { get; set; }

    public string? Instagram { get; set; }

    public string? Twitter { get; set; }

    public string? Etsy { get; set; }

    public string? Linktree { get; set; }

    public string? Facebook { get; set; }

    public string? YouTube { get; set; }

    public virtual User FkUser { get; set; } = null!;

    public virtual ICollection<UsersSocialMediaCustom> UsersSocialMediaCustoms { get; set; } = new List<UsersSocialMediaCustom>();
}
