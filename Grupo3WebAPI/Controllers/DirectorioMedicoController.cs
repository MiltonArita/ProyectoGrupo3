using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grupo3WebAPI.Modelos;
using Grupo3WebAPI.APIModelos;
using Microsoft.AspNetCore.Cors;

namespace Grupo3WebAPI.Controllers
{
    [EnableCors("grupo3Policy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorioMedicoController : ControllerBase
    {
        private Grupo3Context db;
        public DirectorioMedicoController()
        {
            this.db = new Grupo3Context();
        }

        //Get /api/Directorio
        [HttpGet]
        public ActionResult<List<DirectorioB>> GetDirectorioB()
        {
            var consulta = from s in db.DirectorioMedicos
                           select new DirectorioB
                           {
                               IdDcotor = s.IdDoctor,
                               NombreDoctor = s.NombreDoctor,
                               Especialidad = s.Especialidad,
                               ClinicaAsignada = s.ClinicaAsignada,
                           };
            return consulta.ToList();
        }

        //POST /api/Directorio
        [HttpPost]

        public ActionResult<DirectorioB> CreateBook(DirectorioB directorio)
        {
            DirectorioMedico nuevo = new DirectorioMedico();
            nuevo.IdDoctor = directorio.IdDcotor;
            nuevo.NombreDoctor = directorio.NombreDoctor;
            nuevo.Especialidad = directorio.Especialidad;
            nuevo.ClinicaAsignada = directorio.ClinicaAsignada;
            
            db.DirectorioMedicos.Add(nuevo);
            try
            {
                int filasAfectadas = db.SaveChanges();
                if (filasAfectadas > 0)
                    return CreatedAtAction("CreateBook", new { estado = "Creado" });
                else
                    return StatusCode(500);
            }
            catch (Exception e)
            {
                return Conflict();
            }

        }
    }
}
