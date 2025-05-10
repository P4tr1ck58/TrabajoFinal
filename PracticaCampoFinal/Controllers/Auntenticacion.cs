using Microsoft.AspNetCore.Mvc;
using PracticaCampoFinal.Data;
using PracticaCampoFinal.Models;
using Microsoft.AspNetCore.Http;


namespace PracticaCampoFinal.Controllers
{
    public class Auntenticacion : Controller
    {
        private readonly AppDbContext _context;

        public Auntenticacion(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuarios
                    .FirstOrDefault(u => u.Name_Usuario == model.Name_Usuario && u.Contra_Usuario == model.Contra_Usuario);

                if (user != null)
                {
                    HttpContext.Session.SetString("usuario", user.Name_Usuario);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Usuario model)
        {
            if (ModelState.IsValid)
            {
                // Validar si el usuario ya existe
                var existingUser = _context.Usuarios
                    .FirstOrDefault(u => u.Name_Usuario == model.Name_Usuario);

                if (existingUser != null)
                {
                    ModelState.AddModelError("Name_Usuario", "El nombre de usuario ya existe.");
                    return View(model);
                }

                // Guardar nuevo usuario
                _context.Usuarios.Add(model);
                _context.SaveChanges();

                // Iniciar sesión automáticamente (opcional)
                HttpContext.Session.SetString("usuario", model.Name_Usuario);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
