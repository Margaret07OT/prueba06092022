using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prueba06092022.Models;
using prueba06092022.Data;
using Microsoft.EntityFrameworkCore;

namespace prueba06092022.Controllers
{

    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;

        public CatalogoController(ApplicationDbContext context, ILogger<CatalogoController> logger)
        {
            _context= context;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string? searchString)
        {
            var productos= from o in _context.DataProductos select o;
            
            if(!String.IsNullOrEmpty(searchString)){
                  productos = productos.Where(s => s.Name.Contains(searchString));
            }

            return View(await productos.ToListAsync());
        }


         public async Task<IActionResult> Details(int? id){ 
            Productos objProduct = await _context.DataProductos.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}