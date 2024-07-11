using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class EventsBringAndBuy
{
    public int Id { get; set; }

    public int FkEventId { get; set; }

    public int Number { get; set; }

    public virtual Event FkEvent { get; set; } = null!;
}
