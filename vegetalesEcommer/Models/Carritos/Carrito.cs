using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Proyecto_Final1.Data;
using Proyecto_Final1.Usuarios; 

namespace Proyecto_Final1.Carritos
{
    public class Carrito
    {
        [Key]
        public int CarritoId { get; set; }
        public string UsuarioId { get; set; } 
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        
        public virtual ICollection<CarritoItem> Items { get; set; }

        
        public virtual ApplicationUser Usuario { get; set; }
    }
}