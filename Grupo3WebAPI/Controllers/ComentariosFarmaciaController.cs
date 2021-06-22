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
    public class ComentariosFarmaciaController : ControllerBase
    {
        private Grupo3Context db;
        public ComentariosFarmaciaController()
        {
            this.db = new Grupo3Context();
        }

        //Get /api/comentariosfarmacia
        [HttpGet]
        public ActionResult<List<ComentarioB>> GetComentarioB()
        {
            var consulta = from n in db.ComentariosFarmacia
                           select new ComentarioB
                           {
                               IdComentarioFarmacia = n.IdComentarioFarmacia,
                               IdFarmacia = n.IdFarmacia,
                               Comentarios = n.Comentarios,
                               PlanDeAccion = n.PlanDeAccion,
                           };
            return consulta.ToList();
        }

        //POST /api/Comentarios
        [HttpPost]

        public ActionResult<ComentarioB> Createcomen(ComentarioB book)
        {
            ComentariosFarmacium nuevo = new ComentariosFarmacium();
           // nuevo.IdComentarioFarmacia = book.IdComentarioFarmacia;
            nuevo.IdFarmacia = book.IdFarmacia;
            nuevo.Comentarios = book.Comentarios;
            nuevo.PlanDeAccion = book.PlanDeAccion;
            

            db.ComentariosFarmacia.Add(nuevo);
            try
            {
                int filasAfectadas = db.SaveChanges();
                if (filasAfectadas > 0)
                    return CreatedAtAction("Createcomen", new { estado = "Creado" });
                else
                    return StatusCode(500);
            }
            catch (Exception e)
            {
                return Conflict();
            }

        }


        //DELETE /api/Comentarios/100
        [HttpDelete("{id}")]
        public ActionResult<ComentarioB> Deletecomen(int id)
        {
            ComentariosFarmacium encontrado = db.ComentariosFarmacia.Find(id);
            if (encontrado != null)
            {
                db.ComentariosFarmacia.Remove(encontrado);
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

