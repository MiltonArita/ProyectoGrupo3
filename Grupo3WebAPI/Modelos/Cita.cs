using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Grupo3WebAPI.Modelos
{
    public partial class Cita
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdCita { get; set; }
        public int IdCliente { get; set; }
        public int IdDoctor { get; set; }
        [StringLength(50)]
        public string ComentarioAdicional { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaCita { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.Cita))]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdDoctor))]
        [InverseProperty(nameof(DirectorioMedico.Cita))]
        public virtual DirectorioMedico IdDoctorNavigation { get; set; }
        public void mostrarDatos()
        {
            Console.WriteLine("Id Cita: " + IdCita);

            Console.WriteLine("Id Cliente: " + IdCliente);

            Console.WriteLine("Id Doctor: " + IdDoctor);

            Console.WriteLine("ComentarioAdicional: " + ComentarioAdicional);

            Console.WriteLine("Fecha Cita: " + FechaCita);
        }

    }
}
