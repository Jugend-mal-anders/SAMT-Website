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
        public int Street { get; set; }
        public int City { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
