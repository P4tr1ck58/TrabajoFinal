using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaCampoFinal.Data;

namespace PracticaCampoFinal.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;
        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // Lectura de todos los clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        //Lectura de Detalles cliente y vista Cliente
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id_Cliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        //
        public
    }
}
