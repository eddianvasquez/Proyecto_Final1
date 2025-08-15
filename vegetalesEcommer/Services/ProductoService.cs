using Proyecto_Final1.Productos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Final1.Services
{
    public class ProductosService
    {
        // Esto es un ejemplo de datos. En tu aplicación real, esta lista se llenaría desde tu base de datos.
        private readonly List<Producto> _productos = new List<Producto>
        {
            new Producto { ProductoId = 1, Nombre = "Manzanas Orgánicas", Descripcion = "Frescas y crujientes manzanas rojas.", Precio = 2.50m, Stock = 50, Categoria = "Frutas", Origen = "Local", UnidadDeMedida = "kg", EsOrganicoCertificado = true, Temporada = "Todo el año" },
            new Producto { ProductoId = 2, Nombre = "Lechuga Romana", Descripcion = "Lechuga fresca para ensaladas.", Precio = 1.80m, Stock = 30, Categoria = "Vegetales", Origen = "Local", UnidadDeMedida = "unidad", EsOrganicoCertificado = true, Temporada = "Todo el año" },
            new Producto { ProductoId = 3, Nombre = "Zanahorias Orgánicas", Descripcion = "Zanahorias dulces y saludables.", Precio = 3.20m, Stock = 45, Categoria = "Vegetales", Origen = "Local", UnidadDeMedida = "manojo", EsOrganicoCertificado = true, Temporada = "Todo el año" }
        };

        public async Task<List<Producto>> GetProductosAsync()
        {
            return await Task.FromResult(_productos);
        }

        public async Task<Producto?> GetProductoByNombreAsync(string nombre)
        {
            return await Task.FromResult(_productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            return await Task.FromResult(_productos.FirstOrDefault(p => p.ProductoId == id));
        }

        // ✨ Nuevo método para filtrar productos ✨
        public async Task<List<Producto>> BuscarProductosAsync(string searchTerm)
        {
            await Task.Delay(100); // Simular una llamada de red
            return _productos
                .Where(p => p.Nombre.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            p.Descripcion.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}