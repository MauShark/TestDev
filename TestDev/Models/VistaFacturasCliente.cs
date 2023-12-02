using System;
using System.Collections.Generic;

namespace TestDev.Models
{
    public partial class VistaFacturasCliente
    {
        public int FcId { get; set; }
        public DateTime FechaAlta { get; set; }
        public string RazonSocial { get; set; } = null!;
        public string Cuit { get; set; } = null!;
    }
}
