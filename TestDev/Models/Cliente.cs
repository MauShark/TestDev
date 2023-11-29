using System;
using System.Collections.Generic;

namespace TestDev.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            FacturaCabeceras = new HashSet<FacturaCabecera>();
        }

        public int CliId { get; set; }
        public string RazonSocial { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public string? Direccion { get; set; }
        public bool Deshabilitado { get; set; }

        public virtual ICollection<FacturaCabecera> FacturaCabeceras { get; set; }
    }
}
