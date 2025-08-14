using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Proyecto_Final1.Data;
using Proyecto_Final1.Usuarios; 

namespace Proyecto_Final1.Pedidos
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        public string UsuarioId { get; set; } 
        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public int DireccionDeEnvioId { get; set; }

        
        public virtual ApplicationUser Usuario { get; set; }
        public virtual DireccionDeEnvio DireccionDeEnvio { get; set; }
        public virtual ICollection<DetallePedidos> Detalles { get; set; }
    }
}
