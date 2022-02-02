using System;
using System.Collections.Generic;

namespace SAMT_Website.models
{
    public partial class Event
    {
        public Event()
        {
            EventsGuests = new HashSet<EventsGuest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public int FkLocationId { get; set; }

        public virtual Location FkLocation { get; set; }
        public virtual ICollection<EventsGuest> EventsGuests { get; set; }
    }
}
