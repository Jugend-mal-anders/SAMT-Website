using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int FkEventId { get; set; }
        public int FkProductId { get; set; }
        public int FkCashboxId { get; set; }
        public int FkSalesLocationId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Cashbox FkCashbox { get; set; } = null!;
        public virtual Event FkEvent { get; set; } = null!;
        public virtual Product FkProduct { get; set; } = null!;
        public virtual SalesLocation FkSalesLocation { get; set; } = null!;
    }
}
