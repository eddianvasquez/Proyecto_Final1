using System.ComponentModel.DataAnnotations;
using Proyecto_Final1.Productos;


namespace Proyecto_Final1.Carritos
{
    public class CarritoItem
    {
        [Key]
        public int CarritoItemId { get; set; }
        public int CarritoId { get; set; }
        public int ProductoId { get; set; } 
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

       
        public virtual Carrito Carrito { get; set; }
        public virtual Producto Producto { get; set; }
    }
}