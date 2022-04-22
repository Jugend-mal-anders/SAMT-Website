using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class SalesLocation
    {
        public SalesLocation()
        {
            EventsProducts = new HashSet<EventsProduct>();
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageLink { get; set; } = null!;

        public virtual ICollection<EventsProduct> EventsProducts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
