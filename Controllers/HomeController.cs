using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCoreIngWeb.Data;
using MiniCoreIngWeb.Models;

namespace MiniCoreIngWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? fechaInicio, DateTime? fechaFin)
        {
            // Obtener y filtrar los gastos
            var gastos = _context.Gastos
                .Include(g => g.Empleado)
                .ThenInclude(e => e.Departamento)
                .AsQueryable();

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                gastos = gastos.Where(g => g.Fecha >= fechaInicio && g.Fecha <= fechaFin);
            }

            // Enviar todos los datos necesarios a la vista
            ViewBag.Empleados = _context.Empleados.Include(e => e.Departamento).ToList();
            ViewBag.Departamentos = _context.Departamentos.ToList();
            return View(gastos.ToList());
        }

        [HttpPost]
        public IActionResult CrearEmpleado(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                // Guardar el empleado en la base de datos
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Volver a cargar los departamentos en caso de error
            ViewBag.Departamentos = _context.Departamentos.ToList();
            return View("Index");
        }


        [HttpPost]
        public IActionResult CrearDepartamento(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Departamentos.Add(departamento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CrearGasto(Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                _context.Gastos.Add(gasto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleados = _context.Empleados.Include(e => e.Departamento).ToList();
            return RedirectToAction("Index");
        }
    }
}
