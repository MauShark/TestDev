using System;
using System.Collections.Generic;

namespace TestDev.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            FacturaDetalles = new HashSet<FacturaDetalle>();
        }

        public int ArtId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int? Stock { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
