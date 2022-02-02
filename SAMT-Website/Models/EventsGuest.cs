using System;
using System.Collections.Generic;

namespace SAMT_Website.models
{
    public partial class EventsGuest
    {
        public int Id { get; set; }
        public int FkEventId { get; set; }
        public int FkGuestsId { get; set; }

        public virtual Event FkEvent { get; set; }
        public virtual Guest FkGuests { get; set; }
    }
}
