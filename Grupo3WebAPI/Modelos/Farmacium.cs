using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Grupo3WebAPI.Modelos
{
    public partial class Farmacium
    {
        public Farmacium()
        {
            ComentariosFarmacia = new HashSet<ComentariosFarmacium>();
        }

        [Key]
        [Column("idFarmacia")]
        public int IdFarmacia { get; set; }
        public int CodigoArticulo { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string NombreArticulo { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Proveedor { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal PrecioVenta { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal? DescuentoAplicado { get; set; }

        [InverseProperty(nameof(ComentariosFarmacium.IdFarmaciaNavigation))]
        public virtual ICollection<ComentariosFarmacium> ComentariosFarmacia { get; set; }
        public void mostrarDatos()
        {
            Console.WriteLine("IdFarmacia: " + IdFarmacia);

            Console.WriteLine("Codigo Articulo: " + CodigoArticulo);

            Console.WriteLine("Nombre Articulo: " + NombreArticulo);

            Console.WriteLine("Descripcion: " + Descripcion);

            Console.WriteLine("Proveedor " + Proveedor);

            Console.WriteLine("Precio Venta: " + PrecioVenta);

            Console.WriteLine("Descuento Aplicado: " + DescuentoAplicado);
        }
    }
}
