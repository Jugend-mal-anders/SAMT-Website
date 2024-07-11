using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class User
{
    public DateTime LastUpdated { get; set; }

    public int Id { get; set; }

    public string EMail { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ArtistName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Intro text for our social media
    /// </summary>
    public string SocialIntro { get; set; } = null!;

    public virtual ICollection<EventsExhibitorsApply> EventsExhibitorsApplies { get; set; } = new List<EventsExhibitorsApply>();

    public virtual ICollection<EventsShowactApply> EventsShowactApplies { get; set; } = new List<EventsShowactApply>();

    public virtual ICollection<EventsWorkshopsApply> EventsWorkshopsApplies { get; set; } = new List<EventsWorkshopsApply>();

    public virtual ICollection<UsersSocialMedium> UsersSocialMedia { get; set; } = new List<UsersSocialMedium>();
}
