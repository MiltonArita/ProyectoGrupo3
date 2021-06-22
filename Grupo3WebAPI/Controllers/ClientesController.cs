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
    public class ClientesController : ControllerBase
    {
        private Grupo3Context db;
        public ClientesController()
        {
            this.db = new Grupo3Context();
        }

        //Get /api/clientes
        [HttpGet]
        public ActionResult<List<ClientesB>> GetClientes()
        {
            var consulta = from s in db.Clientes
                           select new ClientesB
                           {
                               IdCliente = s.IdCliente,
                               Cliente = s.Cliente1,
                               FechaNacimiento = s.FechaNacimiento,
                               Procedencia = s.Procedencia,
                               Identidad = s.Identidad
                           };
            return consulta.ToList();
        }

        //POST /api/Clientes
        [HttpPost]

        public ActionResult<ClientesB> CreateBook(ClientesB clie)
        {
            Cliente nuevo = new Cliente();
            nuevo.IdCliente = clie.IdCliente;
            nuevo.Cliente1 = clie.Cliente;
            nuevo.FechaNacimiento = (DateTime)clie.FechaNacimiento;
            nuevo.Procedencia = clie.Procedencia;
            nuevo.Identidad = clie.Identidad;

            db.Clientes.Add(nuevo);
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


        //DELETE /api/Clientes/100
        [HttpDelete("{id}")]
        public ActionResult<ClientesB> DeleteBook(int id)
        {
            Cliente encontrado = db.Clientes.Find(id);
            if (encontrado != null)
            {
                db.Clientes.Remove(encontrado);
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
