using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grupo3WebAPI.Modelos;
using Grupo3WebAPI.APIModelos;
namespace Grupo3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciumController : ControllerBase
    {
        private Grupo3Context db;
        public FarmaciumController()
        {
            this.db = new Grupo3Context();
        }

        //Get /api/Farmacia
        [HttpGet]
        public ActionResult<List<FarmaciaB>> GetFarmacia()
        {
            var consulta = from s in db.Farmacia
                           select new FarmaciaB
                           {
                               idFarmacia = s.IdFarmacia,
                               CodigoArticulo = s.CodigoArticulo,
                               NombreArticulo = s.NombreArticulo,
                               Descripcion = s.Descripcion,
                               Proveedor = s.Proveedor,
                               PrecioVenta = s.PrecioVenta,
                               DescuentoAplicado = (decimal)s.DescuentoAplicado
                           };
            return consulta.ToList();
        }
    }
   

}
