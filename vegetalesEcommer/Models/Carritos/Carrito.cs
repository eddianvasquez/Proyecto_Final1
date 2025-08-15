using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Agregado para el atributo [DatabaseGenerated]
using Proyecto_Final1.Data;
using Proyecto_Final1.Usuarios;

namespace Proyecto_Final1.Carritos
{
    public class Carrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarritoId { get; set; }

        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        public string UsuarioId { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;

        // Propiedades de navegación
        public virtual ICollection<CarritoItem> Items { get; set; } = new List<CarritoItem>();

        public virtual ApplicationUser Usuario { get; set; }
    }
}