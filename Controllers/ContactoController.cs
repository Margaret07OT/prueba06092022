using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prueba06092022.Models;
using prueba06092022.Data;


namespace prueba06092022.Controllers
{


    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;
        private readonly ApplicationDbContext _context;


        public ContactoController(ILogger<ContactoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context= context;
        }

        public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public async Task<IActionResult> Create(Contacto objContacto)
        {
         
         _context.Add(objContacto);
         _context.SaveChanges();
         return View ("Index");
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