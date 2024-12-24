using System.ComponentModel.DataAnnotations;

namespace MiniCoreIngWeb.Models
{
    public class Departamento
    {
        public int DepartamentoID { get; set; }

        [Required(ErrorMessage = "El nombre del departamento es obligatorio.")]
        public string Nombre { get; set; } = null!;
    }
}
