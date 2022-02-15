using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int FkEventId { get; set; }
        public int FkProductId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Event FkEvent { get; set; } = null!;
        public virtual Product FkProduct { get; set; } = null!;
    }
}
