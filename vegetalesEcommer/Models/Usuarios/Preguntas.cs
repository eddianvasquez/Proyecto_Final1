using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Para [ForeignKey]
using Proyecto_Final1.Data; // Para ApplicationUser

namespace Proyecto_Final1.Models.Usuarios
{
    public class Preguntas
    {
        [Key]
        public int PreguntaId { get; set; }

        [Required(ErrorMessage = "El ID de usuario es obligatorio.")]
        public string UsuarioId { get; set; } // ID del usuario que envía la pregunta

        [ForeignKey("UsuarioId")]
        public virtual ApplicationUser Usuario { get; set; } // Navegación al usuario

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido.")]
        [StringLength(150, ErrorMessage = "El correo electrónico no puede exceder 150 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La pregunta es obligatoria.")]
        [StringLength(1000, ErrorMessage = "La pregunta no puede exceder 1000 caracteres.")]
        public string Question { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de envío es obligatoria.")]
        public DateTime FechaEnvio { get; set; }
    }
}