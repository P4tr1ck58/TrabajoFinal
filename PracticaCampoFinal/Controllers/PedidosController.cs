using Microsoft.AspNetCore.Mvc;
using PracticaCampoFinal.Data;
using PracticaCampoFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PracticaCampoFinal.Controllers
{
    public class PedidosController : Controller
    {
        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuario = HttpContext.Session.GetString("usuario");

            if (usuario == null)
            {
                return RedirectToAction("Login", "Auntenticacion");
            }

            var pedidos = _context.Pedidos.Include(p => p.Cliente).ToList();
            return View(pedidos);
        }

        public IActionResult Create()
        {
            ViewData["Id_Cliente"] = new SelectList(_context.Clientes, "Id_Cliente", "Name_Cliente");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.Fecha_Pedido = DateTime.Now;
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Cliente"] = new SelectList(_context.Clientes, "Id_Cliente", "Name_Cliente");
            return View(pedido);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return NotFound();

            ViewData["Id_Cliente"] = new SelectList(_context.Clientes, "Id_Cliente", "Name_Cliente", pedido.Id_Cliente);
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pedido pedido)
        {
            if (id != pedido.Id_Pedido) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Cliente"] = new SelectList(_context.Clientes, "Id_Cliente", "Name_Cliente", pedido.Id_Cliente);
            return View(pedido);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(p => p.Id_Pedido == id);
            if (pedido == null) return NotFound();
            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(p => p.Id_Pedido == id);
            if (pedido == null) return NotFound();
            return View(pedido);
        }

    }
}
