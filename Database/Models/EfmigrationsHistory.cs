using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class EfmigrationsHistory
{
    public string MigrationId { get; set; } = null!;

    public string ProductVersion { get; set; } = null!;
}
