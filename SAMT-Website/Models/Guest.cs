using System;
using System.Collections.Generic;

namespace SAMT_Website.models
{
    public partial class Guest
    {
        public Guest()
        {
            EventsGuests = new HashSet<EventsGuest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ImageLink { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Linktree { get; set; }

        public virtual ICollection<EventsGuest> EventsGuests { get; set; }
    }
}
