using System.ComponentModel.DataAnnotations;

namespace MiniCoreIngWeb.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }

        [Required(ErrorMessage = "El nombre del empleado es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Debe seleccionar un departamento.")]
        public int DepartamentoID { get; set; }

        public Departamento Departamento { get; set; } = null!;
    }
}
