using System;
using System.Collections.Generic;

namespace TestDev.Models
{
    public partial class VistaFactura
    {
        public int FcId { get; set; }
        public string? Estado { get; set; }
        public decimal? Total { get; set; }
    }
}
