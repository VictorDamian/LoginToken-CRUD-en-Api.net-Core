using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore.Models.DTO
{
    public class Producto
    {
        public int Id_pro { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public double Costo { get; set; }
    }
}
