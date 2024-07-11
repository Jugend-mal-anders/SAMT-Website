using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class EventsWorkshopsApply
{
    public int Id { get; set; }

    public int FkEventId { get; set; }

    public int FkUserId { get; set; }

    public string WorkshopName { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    /// <summary>
    /// 1 = &apos;DIY workshop (e.g. handicrafts, synchro, game rounds, etc.)&apos;
    /// 2 = &apos;Round table discussion&apos;
    /// 3 = &apos;Lecture (Educational program)&apos;
    /// </summary>
    public int Type { get; set; }

    public string? TypeOther { get; set; }

    /// <summary>
    /// Materialien, Beamer, Whiteboard, Stifte, Fernseher, etc.
    /// </summary>
    public string? EquipmentNeeds { get; set; }

    public int NumberMaxParticipants { get; set; }

    /// <summary>
    /// 1 = &apos;30 minutes&apos;
    /// 2 = &apos;1 hour&apos;
    /// 3 = &apos;1 hour 30 minutes&apos;
    /// 4 = &apos;Up to 2 hours&apos;
    /// 5 = &apos;More than 2 hours&apos;
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// 1 = &apos;Yes&apos;
    /// 2 = &apos;No&apos;
    /// 3 = &apos;I don&apos;&apos;t know yet&apos;
    /// </summary>
    public int Fee { get; set; }

    public float? FeeNumber { get; set; }

    public string? Questions { get; set; }

    public virtual Event FkEvent { get; set; } = null!;

    public virtual User FkUser { get; set; } = null!;
}
