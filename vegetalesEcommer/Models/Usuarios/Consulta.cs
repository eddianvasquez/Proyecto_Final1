using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Para [ForeignKey]
using Proyecto_Final1.Data; // Para ApplicationUser

namespace Proyecto_Final1.Models.Usuarios
{
    public class Consulta
    {
        [Key]
        public int ConsultaId { get; set; }

        
        public string UsuarioId { get; set; } // ID del usuario que envía la consulta

        [ForeignKey("UsuarioId")]
        public virtual ApplicationUser Usuario { get; set; } // Navegación al usuario

        [Required(ErrorMessage = "El asunto de la consulta es obligatorio.")]
        [StringLength(200, ErrorMessage = "El asunto no puede exceder los 200 caracteres.")]
        public string Asunto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El mensaje de la consulta es obligatorio.")]
        [StringLength(2000, ErrorMessage = "El mensaje no puede exceder los 2000 caracteres.")]
        public string Mensaje { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de envío es obligatoria.")]
        public DateTime FechaEnvio { get; set; }
    }
}