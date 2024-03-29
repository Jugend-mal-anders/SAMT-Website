﻿using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Guest
    {
        public Guest()
        {
            EventsGuests = new HashSet<EventsGuest>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? ImageLink { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Etsy { get; set; }
        public string? Linktree { get; set; }
        public string? EMail { get; set; }

        public virtual ICollection<EventsGuest> EventsGuests { get; set; }
    }
}
