using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class EventsExhibitorsApply
{
    public int Id { get; set; }

    public int FkEventId { get; set; }

    public int FkUserId { get; set; }

    /// <summary>
    /// We try to pay attention to diversity and a different offering to the advantage of both exhibitors and visitors
    /// </summary>
    public string ShortIntro { get; set; } = null!;

    public int Tables { get; set; }

    /// <summary>
    /// 1 = &apos;Sadly, that is not possible.&apos;
    /// 2 = &apos;Yes, could drop half a table (-0.5 table)&apos;
    /// 3 = &apos;Yes, could give up a whole table (-1 table)&apos;
    /// 4 = &apos;Yes, could give away 2 tables (-2 tables)&apos;
    /// </summary>
    public int LessTable { get; set; }

    public string? Neighbors { get; set; }

    public string? CoExhibitor { get; set; }

    public string? Questions { get; set; }

    public virtual Event FkEvent { get; set; } = null!;

    public virtual User FkUser { get; set; } = null!;
}
