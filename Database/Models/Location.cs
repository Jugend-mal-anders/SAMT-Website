using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Location
    {
        public Location()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string MapsLink { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int Number { get; set; }
        public string City { get; set; } = null!;
        public int Plz { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
