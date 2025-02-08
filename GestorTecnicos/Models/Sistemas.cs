using System.ComponentModel.DataAnnotations;

namespace GestorTecnicos.Models
{
    public class Sistemas
    {
        [Key]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "La Descripcion no puede tener mas de 100 caracteres.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Range(0.01, 100, ErrorMessage = "El valor debe estar entre 0.01 y 100")]
        public double Complejidad { get; set; }
    }
}
