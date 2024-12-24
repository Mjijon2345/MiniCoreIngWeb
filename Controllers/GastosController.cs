using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCoreIngWeb.Data;
using MiniCoreIngWeb.Models;

namespace MiniCoreIngWeb.Controllers
{
    public class GastosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GastosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var gastos = _context.Gastos
                .Include(g => g.Empleado)
                .ThenInclude(e => e.Departamento)
                .AsQueryable();

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                gastos = gastos.Where(g => g.Fecha >= fechaInicio && g.Fecha <= fechaFin);
            }

            return View(gastos.ToList());
        }
    }
}
