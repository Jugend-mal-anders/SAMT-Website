using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class EventsDateTime
{
    public int Id { get; set; }

    public int FkEventId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual Event FkEvent { get; set; } = null!;
}
