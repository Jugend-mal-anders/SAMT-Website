using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class SalesLocation
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageLink { get; set; } = null!;
    }
}
