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
    public class CitasController : ControllerBase
    {
        private Grupo3Context db;
        public CitasController()
        {
            this.db = new Grupo3Context();
        }

        //Get /api/citas
        [HttpGet]
        public ActionResult<List<CitasB>> GetCitas()
        {
            var consulta = from s in db.Citas
                           select new CitasB
                           {
                               IdCita = s.IdCita,
                               IdCliente = s.IdCliente,
                               IdDoctor = s.IdDoctor,
                               ComentarioAdicional = s.ComentarioAdicional,
                               FechaCita = s.FechaCita
                           };
            return consulta.ToList();
        }


       /* //GET /api/Citas/2
        [HttpGet("{id}")]
        public ActionResult<CitasB> GetCitas(int id)

        {
            Cita encontrado = db.Citas.Find(id);

            if (encontrado != null)
            {
                CitasB nuevo = new CitasB();
                nuevo.IdCita = encontrado.IdCita;
                nuevo.IdCliente = encontrado.IdCliente;
                nuevo.IdDoctor = encontrado.IdDoctor;
                nuevo.ComentarioAdicional = encontrado.ComentarioAdicional;
                nuevo.FechaCita = encontrado.FechaCita;
                return nuevo;
            }
            else
                return NotFound();
        }
       */




        //POST /api/Citas
        [HttpPost]

        public ActionResult<CitasB> CreateBook(CitasB cita)
        {
            Cita nuevo = new Cita();
           // nuevo.IdCita = cita.IdCita;
            nuevo.IdCliente = cita.IdCliente;
            nuevo.IdDoctor = cita.IdDoctor;
            nuevo.ComentarioAdicional = cita.ComentarioAdicional;
            nuevo.FechaCita = (DateTime)cita.FechaCita;

            db.Citas.Add(nuevo);
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

        //DELETE /api/Citas/100
        [HttpDelete("{id}")]
        public  ActionResult<CitasB> DeleteCitasB(int id)
        {
            Cita encontrado =  db.Citas.Find(id);
            if (encontrado != null)
            {
                db.Citas.Remove(encontrado);
                int filasAfectadas = db.SaveChanges();
                if (filasAfectadas > 0)
                    return Ok(new { estado = "Eliminado" });
                else
                    return StatusCode(500);
            }
            else
                return NotFound();
        }

    }
}
