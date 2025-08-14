using System.ComponentModel.DataAnnotations;
using Proyecto_Final1.Productos;

namespace Proyecto_Final1.Pedidos
{
    public class DetallePedidos
    {
        [Key]
        public int DetallePedidoId { get; set; } 
        public int PedidoId { get; set; } 
        public int ProductoId { get; set; } 
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        
        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}