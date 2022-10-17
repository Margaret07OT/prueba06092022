using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prueba06092022.Models;
using Microsoft.AspNetCore.Identity;
using prueba06092022.DTO;
using prueba06092022.Data;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;

/// <summary>
///  Aka Carrito
/// </summary>

namespace prueba06092022.Controllers
{
   
    public class ProformaController : Controller
    {
        private readonly ILogger<ProformaController> _logger;
        
        private readonly ApplicationDbContext _context;
       
        private readonly UserManager<IdentityUser> _userManager;

        public ProformaController(ILogger<ProformaController> logger,
                                  ApplicationDbContext context,
                                  UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context= context;
            _userManager = userManager;

        }
 public IActionResult Index()
        {
            var userIDSession = _userManager.GetUserName(User);
            //SELECT * FROM Proforma p,Producto pr WHERE p.productId=pr.Id And p.UserId=? And p.status='PENDIENTE' 
            
            // selecciona todos los datos de la proforma donde icluye la tabla producto 

            var items = from o in _context.DataProforma select o; //recursividad
            items = items.Include(p => p.Producto).
                    Where(w => w.UserID.Equals(userIDSession) &&
                     w.Status.Equals("PENDIENTE"));
            var itemsCarrito = items.ToList();
            
            //Fila1 1234, Shampo; Precio, Cantidad
            //Fila2 12345, Shampo3; Precio, Cantidad
            var total = itemsCarrito.Sum(c => c.Cantidad * c.Precio);// sumar todos los datos del carrito


            //MEMORIA EN RUN TIME EN TIEMPO DE EJECUCIÓN 

            dynamic model = new ExpandoObject();// Crea una clase en tiempo de ejecución
            model.montoTotal = total;// le pone un valor y los atos del carrito, le pasas un objeto dinámico
            model.elementosCarrito = itemsCarrito;

           // sino se usa EXPAND OBJECT  creando el DTO

            //Carrito carrito = new Carrito();
            //carrito.total = total;
            //carrito.itemsCarrito = itemsCarrito;

            //return View(carrito);
            return View(model);
        }


         public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.DataProforma.FindAsync(id);
            if (proforma == null)
            {
                return NotFound();
            }
            return View(proforma);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,Precio,UserID")] Proforma proforma)
        {
            if (id != proforma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proforma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.DataProforma.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proforma);
        }

       public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.DataProforma.FindAsync(id);
            _context.DataProforma.Remove(proforma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }        

        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
        

        
    }
