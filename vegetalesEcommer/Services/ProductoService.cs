namespace Proyecto_Final1.Services
{
    public class ProductoService
    {
        private List<Product> products = new();

        public ProductoService()
        {
            LoadProducts();
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        private void LoadProducts()
        {
            products = new List<Product>
            {
              
            };
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}