using Microsoft.AspNetCore.Mvc;
using MiniCoreIngWeb.Data;
using MiniCoreIngWeb.Models;

namespace MiniCoreIngWeb.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Departamentos.Add(departamento);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(departamento);
        }
    }
}
