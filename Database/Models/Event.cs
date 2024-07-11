using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageLink { get; set; } = null!;

    public int FkLocationId { get; set; }

    public DateOnly? ApplyOpen { get; set; }

    public DateOnly? ApplyClose { get; set; }

    public bool? BringAndBuy { get; set; }

    public float Price { get; set; }

    public virtual ICollection<EventsBringAndBuy> EventsBringAndBuys { get; set; } = new List<EventsBringAndBuy>();

    public virtual ICollection<EventsDateTime> EventsDateTimes { get; set; } = new List<EventsDateTime>();

    public virtual ICollection<EventsExhibitorsApply> EventsExhibitorsApplies { get; set; } = new List<EventsExhibitorsApply>();

    public virtual ICollection<EventsShowactApply> EventsShowactApplies { get; set; } = new List<EventsShowactApply>();

    public virtual ICollection<EventsWorkshopsApply> EventsWorkshopsApplies { get; set; } = new List<EventsWorkshopsApply>();

    public virtual Location FkLocation { get; set; } = null!;
}
