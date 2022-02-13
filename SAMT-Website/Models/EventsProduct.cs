using System;
using System.Collections.Generic;

namespace SAMT_Website.Models
{
    public partial class EventsProduct
    {
        public int Id { get; set; }
        public int FkEventId { get; set; }
        public int FkProductId { get; set; }
        public double? Price { get; set; }

        public virtual Event FkEvent { get; set; }
        public virtual Product FkProduct { get; set; }
    }
}
