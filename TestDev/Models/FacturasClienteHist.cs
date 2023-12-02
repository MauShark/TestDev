using System;
using System.Collections.Generic;

namespace TestDev.Models
{
    public partial class FacturasClienteHist
    {
        public int Id { get; set; }
        public int FcCabeceraId { get; set; }
        public int ClienteId { get; set; }
        public DateTime? FecCreaReg { get; set; }
    }
}
