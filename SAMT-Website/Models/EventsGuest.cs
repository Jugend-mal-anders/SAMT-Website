using System;
using System.Collections.Generic;

namespace SAMT_Website.models
{
    public partial class EventsGuest
    {
        public int EventId { get; set; }
        public int GuestId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Guest Guest { get; set; }
    }
}
