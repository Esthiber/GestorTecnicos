using System.ComponentModel.DataAnnotations;

namespace GestorTecnicos.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El Nombre es Requerido")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "En este campo solo se permiten letras.")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "La direccion es Requerido")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "El RNC es Requerido")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "El RNC debe contener 9 digitos.")]
        public string? Rnc { get; set; }

        [Required(ErrorMessage = "El Limite de Credito es Requerido")]
        [Range(minimum: 0.1, double.MaxValue, ErrorMessage = "Por favor, ingrese una cantidad mayor a 0.")]
        public double LimiteCredito { get; set; }

        [Required(ErrorMessage = "El Tecnico es Requerido")]
        [Range(minimum: 1, int.MaxValue, ErrorMessage = "Por favor, seleccione un tecnico.")]
        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "La Ciudad es Requerida")]
        [Range(minimum: 1, int.MaxValue, ErrorMessage = "Por favor, seleccione una ciudad.")]
        public int CiudadId { get; set; }

    }
}
