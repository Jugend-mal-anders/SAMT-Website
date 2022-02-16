using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Cashbox
    {
        public Cashbox()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageLink { get; set; }
        public double Money { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
