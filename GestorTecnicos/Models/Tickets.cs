using System.ComponentModel.DataAnnotations;

namespace GestorTecnicos.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "La Fecha es Requerida")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Seleccione la Prioridad")]
        [Range(1, 4, ErrorMessage = "La Prioridad debe ser de 1 a 4")]
        public int Prioridad { get; set; }

        [Required(ErrorMessage = "Seleccione el Cliente")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione el Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Seleccione el Técnico")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione el Técnico")]
        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "Describa el Asunto")]
        public string? Asunto { get; set; }

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el Tiempo Invertido")]
        public int TiempoInvertido { get; set; }

    }
}
