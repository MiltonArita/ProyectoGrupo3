using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo3WebAPI.APIModelos
{
    public class ClientesB
    { 
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Procedencia { get; set; }
        public string Identidad { get; set; }


    }
}
