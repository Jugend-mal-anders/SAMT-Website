using System;
using System.Collections.Generic;

namespace SAMT_Website.models
{
    public partial class Location
    {
        public Location()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string MapsLink { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public int Plz { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
