using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Grupo3WebAPI.Modelos
{
    [Table("DirectorioMedico")]
    public partial class DirectorioMedico
    {
        public DirectorioMedico()
        {
            Cita = new HashSet<Cita>();
        }

        [Key]
        public int IdDoctor { get; set; }
        [Required]
        [StringLength(50)]
        public string NombreDoctor { get; set; }
        [Required]
        [StringLength(50)]
        public string Especialidad { get; set; }
        [Required]
        [StringLength(10)]
        public string ClinicaAsignada { get; set; }

        [InverseProperty("IdDoctorNavigation")]
        public virtual ICollection<Cita> Cita { get; set; }
        public void mostrarDatos()
        {
            Console.WriteLine("Id Doctor: " + IdDoctor);

            Console.WriteLine("Nombre Doctor: " + NombreDoctor);

            Console.WriteLine("Especialidad: " + Especialidad);

            Console.WriteLine("Clinica Asignada: " + ClinicaAsignada);

        }
    }
}
