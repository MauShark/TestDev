using System;
using System.Collections.Generic;

namespace TestDev.Models
{
    public partial class FacturaDetalle
    {
        public int FactId { get; set; }
        public int FcDtlId { get; set; }
        public DateTime FechaAlta { get; set; }
        public int ArtId { get; set; }
        public decimal? Cant { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Monto { get; set; }

        public virtual Articulo Art { get; set; } = null!;
        public virtual FacturaCabecera Fact { get; set; } = null!;
    }
}
