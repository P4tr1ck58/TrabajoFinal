using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaCampoFinal.Data;
using PracticaCampoFinal.Models;

namespace PracticaCampoFinal.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.Id_Usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);

        }
        
        //Funcion de eliminar
        public async Task<IActionResult> Delete(int id) 
        {
            var usuario = await _context.Usuarios.FindAsync(id); // Busca el usuario por id
            if (usuario == null) // Si el usuario no se encuentra retorna un error 404
            {
                return NotFound();
            }
            return View(usuario); // Si el usuario se encuentra, retorna la vista de eliminar
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // Funcion que Elimina el usuario
        {
            var usuario = await _context.Usuarios.FindAsync(id); // Busca el usuario por id
            _context.Usuarios.Remove(usuario); // Elimina el usuario
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            return RedirectToAction(nameof(Index)); // Redirecciona a la vista de usuarios
        }

        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id); // Busca el usuario por id
            if (usuario == null) // Si el usuario no se encuentra retorna un error 404
            {
                return NotFound();
            }
            return View(usuario); // Si el usuario se encuentra, retorna la vista de detalles
        }
    }
}
