using System;
using System.Collections.Generic;

namespace SAMT_Website.models
{
    public partial class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Linktree { get; set; }
    }
}
