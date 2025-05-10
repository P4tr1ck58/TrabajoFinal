using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaCampoFinal.Data;
using PracticaCampoFinal.Models;

namespace PracticaCampoFinal.Controllers
{
    public class PedidosDetalleController : Controller
    {
        private readonly AppDbContext _context;

        public PedidosDetalleController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var detalles = _context.PedidosDetalles
                .Include(d => d.Pedido)
                .Include(d => d.Producto);
            return View(await detalles.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Id_Pedido"] = new SelectList(_context.Pedidos, "Id_Pedido", "Id_Pedido");
            ViewData["Id_Producto"] = new SelectList(_context.Productos, "Id_Producto", "Name_Producto");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedidosdetalle detalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Pedido"] = new SelectList(_context.Pedidos, "Id_Pedido", "Id_Pedido", detalle.Id_Pedido);
            ViewData["Id_Producto"] = new SelectList(_context.Productos, "Id_Producto", "Name_Producto", detalle.Id_Producto);
            return View(detalle);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var detalle = await _context.PedidosDetalles.FindAsync(id);
            if (detalle == null) return NotFound();

            ViewData["Id_Pedido"] = new SelectList(_context.Pedidos, "Id_Pedido", "Id_Pedido", detalle.Id_Pedido);
            ViewData["Id_Producto"] = new SelectList(_context.Productos, "Id_Producto", "Name_Producto", detalle.Id_Producto);
            return View(detalle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pedidosdetalle detalle)
        {
            if (id != detalle.Id_PedidoDetalle) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(detalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Id_Pedido"] = new SelectList(_context.Pedidos, "Id_Pedido", "Id_Pedido", detalle.Id_Pedido);
            ViewData["Id_Producto"] = new SelectList(_context.Productos, "Id_Producto", "Name_Producto", detalle.Id_Producto);
            return View(detalle);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var detalle = await _context.PedidosDetalles
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id_PedidoDetalle == id);

            if (detalle == null) return NotFound();
            return View(detalle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalle = await _context.PedidosDetalles.FindAsync(id);
            _context.PedidosDetalles.Remove(detalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var detalle = await _context.PedidosDetalles
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id_PedidoDetalle == id);

            if (detalle == null) return NotFound();
            return View(detalle);
        }
    }
}
