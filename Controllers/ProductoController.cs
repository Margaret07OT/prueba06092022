using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba06092022.Data;
using prueba06092022.Models;

namespace prueba06092022.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Producto
        public async Task<IActionResult> Index()
        {
              return _context.DataProductos != null ? 
                          View(await _context.DataProductos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DataProductos'  is null.");
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DataProductos == null)
            {
                return NotFound();
            }

            var productos = await _context.DataProductos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Descripcion,Precio,PorcentajeDescuento,ImageName,Status")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DataProductos == null)
            {
                return NotFound();
            }

            var productos = await _context.DataProductos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descripcion,Precio,PorcentajeDescuento,ImageName,Status")] Productos productos)
        {
            if (id != productos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.Id))
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
            return View(productos);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DataProductos == null)
            {
                return NotFound();
            }

            var productos = await _context.DataProductos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataProductos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DataProductos'  is null.");
            }
            var productos = await _context.DataProductos.FindAsync(id);
            if (productos != null)
            {
                _context.DataProductos.Remove(productos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
          return (_context.DataProductos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
