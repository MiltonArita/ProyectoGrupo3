using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo3WebAPI.APIModelos
{
    public class FarmaciaB
    {
        public int idFarmacia { get; set; }
        public int CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string Descripcion { get; set; }
        public string Proveedor { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal DescuentoAplicado { get; set; }
    }
}
