using System.ComponentModel.DataAnnotations;
using Proyecto_Final1.Productos;

namespace Proyecto_Final1.Pedidos
{
    public class DetallePedidos
    {
        [Key]
        public int DetallePedidoId { get; set; }

        [Required(ErrorMessage = "El ID del pedido es obligatorio.")]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "El ID del producto es obligatorio.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor que cero.")]
        public decimal PrecioUnitario { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}