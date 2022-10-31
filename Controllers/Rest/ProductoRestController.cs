using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using prueba06092022.Data;
using prueba06092022.Models;


namespace prueba06092022.Controllers.Rest
{
    [ApiController]
    [Route("api/[[productos]]")]
    public class ProductoRestController : ControllerBase
    {
       private readonly ApplicationDbContext _context;

        public ProductoRestController(ApplicationDbContext context){
             _context = context;
        }

/*LOS CONTRATOS- PETICIONES */
        [HttpGet] /* LISTAR PRODUCTOS Y LO MUESTRA*/
        public IEnumerable<Productos> ListProductos()
        {
             var listProductos=_context.DataProductos.OrderBy(s => s.Id).ToList();   
             return listProductos.ToArray();
        }
 
    }
}