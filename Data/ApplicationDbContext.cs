using Microsoft.EntityFrameworkCore;
using MiniCoreIngWeb.Models;

namespace MiniCoreIngWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
    }
}
