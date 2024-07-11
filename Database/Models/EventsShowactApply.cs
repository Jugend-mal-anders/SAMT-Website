using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class EventsShowactApply
{
    public int Id { get; set; }

    public int FkEventId { get; set; }

    public int FkUserId { get; set; }

    public string ShortIntro { get; set; } = null!;

    /// <summary>
    /// 1 = &apos;Dance&apos;
    /// 2 = &apos;Cosplay, Showfights, Acting etc.&apos;
    /// 3 = &apos;Interactive program with the audience&apos;
    /// 4 = &apos;Singing, Music&apos;
    /// 5 = &apos;Educational, informative program&apos;
    /// 6 = &apos;none of the above&apos;
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 1 = &apos;1&apos;
    /// 2 = &apos;2-3&apos;
    /// 3 = &apos;4-6&apos;
    /// 4 = &apos;7-10&apos;
    /// 5 = &apos;10+&apos;
    /// </summary>
    public int NumberActors { get; set; }

    /// <summary>
    /// special lightning, music, a whiteboard, pens etc.
    /// </summary>
    public string? EquipmentNeeds { get; set; }

    /// <summary>
    /// 1 = &apos;20 minutes&apos;
    /// 2 = &apos;30 minutes&apos;
    /// 3 = &apos;45 minutes&apos;
    /// 4 = &apos;1 hour&apos;
    /// 5 = &apos;More than 1 hour&apos;
    /// </summary>
    public int Duration { get; set; }

    public string? Questions { get; set; }

    public virtual Event FkEvent { get; set; } = null!;

    public virtual User FkUser { get; set; } = null!;
}
