﻿using System;
using System.Collections.Generic;

namespace TestDev.Models
{
    public partial class FacturaCabecera
    {
        public FacturaCabecera()
        {
            FacturaDetalles = new HashSet<FacturaDetalle>();
        }

        public int FcId { get; set; }
        public DateTime FechaAlta { get; set; }
        public int CliId { get; set; }
        public string? Estado { get; set; }

        public virtual Cliente Cli { get; set; } = null!;
        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
