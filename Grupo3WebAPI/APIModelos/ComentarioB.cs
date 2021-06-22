using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo3WebAPI.APIModelos
{
    public class ComentarioB
    {
        public int IdComentarioFarmacia { get; set; }
        public int IdFarmacia { get; set; }
        public string Comentarios { get; set; }
        public string PlanDeAccion { get; set; }

    }
}
