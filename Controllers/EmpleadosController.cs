using Microsoft.AspNetCore.Mvc;
using MiniCoreIngWeb.Data;
using MiniCoreIngWeb.Models;

namespace MiniCoreIngWeb.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Departamentos = _context.Departamentos.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Departamentos = _context.Departamentos.ToList();
            return View(empleado);
        }
    }
}
