using System.ComponentModel.DataAnnotations;

namespace GestorTecnicos.Models
{
    public class Ciudades
    {
        [Key]
        public int CiudadId { get; set; }
        [Required(ErrorMessage="Debe ingresar el nombre de ciudad.")]
        [RegularExpression(@"^(?!\s*$).{2,}$", ErrorMessage = "El nombre debe tener al menos 2 caracteres y no puede contener solo espacios en blanco.")]
        public string? Nombre { get; set; }
    }
}
