using System; // Agregado para DateTime?
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final1.Productos
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string Descripcion { get; set; } = string.Empty; 

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; } = string.Empty; 

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }

        
        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "El origen es obligatorio.")]
        public string Origen { get; set; } = string.Empty; 

        [Required(ErrorMessage = "La unidad de medida es obligatoria.")]
        public string UnidadDeMedida { get; set; } = string.Empty; 

        [Display(Name = "Orgánico Certificado")]
        public bool EsOrganicoCertificado { get; set; } 

        public string? Temporada { get; set; }
        public virtual ICollection<ProductoVariacion> Variaciones { get; set; } = new List<ProductoVariacion>();
        public virtual ICollection<Valoracion> Valoraciones { get; set; } = new List<Valoracion>();
    }
}
