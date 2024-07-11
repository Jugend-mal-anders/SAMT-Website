using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class UsersSocialMediaCustom
{
    public int Id { get; set; }

    public int FkUserSocialMediaId { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;

    public virtual UsersSocialMedium FkUserSocialMedia { get; set; } = null!;
}
