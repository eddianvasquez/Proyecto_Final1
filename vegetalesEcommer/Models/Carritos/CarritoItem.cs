using System.ComponentModel.DataAnnotations;
using Proyecto_Final1.Productos;

namespace Proyecto_Final1.Carritos
{
    public class CarritoItem
    {
        [Key]
        public int CarritoItemId { get; set; }

        [Required(ErrorMessage = "El ID del carrito es obligatorio.")]
        public int CarritoId { get; set; }

        [Required(ErrorMessage = "El ID del producto es obligatorio.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor que cero.")]
        public decimal PrecioUnitario { get; set; }

        // Propiedades de navegación
        public virtual Carrito Carrito { get; set; }
        public virtual Producto Producto { get; set; }
    }
}