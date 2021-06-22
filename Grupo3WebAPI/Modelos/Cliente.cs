using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Grupo3WebAPI.Modelos
{
    public partial class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int IdCliente { get; set; }
        [Required]
        [Column("Cliente")]
        [StringLength(50)]
        public string Cliente1 { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [StringLength(50)]
        public string Procedencia { get; set; }
        [Required]
        [StringLength(50)]
        public string Identidad { get; set; }

        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<Cita> Cita { get; set; }

        public void mostrarDatos()
        {
            Console.WriteLine("Id CLiente: " + IdCliente);

            Console.WriteLine("Nombre CLiente: " + Cliente1);

            Console.WriteLine("Fecha Nacimiento: " + FechaNacimiento);

            Console.WriteLine("Procedencia: " + Procedencia);

            Console.WriteLine("Identidad: " + Identidad);
        }
    }
}
