using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore.Models.DTO
{
    public class DetalleVenta
    {
        public int IddVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Importe { get; set; }
    }
}
