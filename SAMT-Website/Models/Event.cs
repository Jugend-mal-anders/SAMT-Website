using System;
using System.Collections.Generic;

namespace SAMT_Website.models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
