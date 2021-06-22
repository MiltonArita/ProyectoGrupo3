using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo3WebAPI.APIModelos
{
    public class CitasB
    {
        public int IdCita { get; set; }
        public int IdCliente { get; set; }
        public int IdDoctor { get; set; }
        public string ComentarioAdicional { get; set; }
        public DateTime? FechaCita { get; set; }
    }
}
