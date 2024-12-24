using System.ComponentModel.DataAnnotations;

namespace MiniCoreIngWeb.Models
{
    public class Gasto
    {
        public int GastoID { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un empleado.")]
        public int EmpleadoID { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        public Empleado Empleado { get; set; } = null!;
    }
}
