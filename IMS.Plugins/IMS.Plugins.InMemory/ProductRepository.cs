using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
       
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product { ProductId = 1, ProductName = "Bike", Quantity = 10,Price = 150},
                new Product { ProductId = 2, ProductName = "Car", Quantity = 10,Price = 9999},
               

            };
        }

        public Task AddProductAsync(Product inventory)
        {
            if(_products.Any(x=> x.ProductName.Equals(inventory.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }
            if(_products.Count != 0)
            {
                var maxId = _products.Max(x => x.ProductId);
                inventory.ProductId = maxId + 1;
            }
            else
            {
                inventory.ProductId = 1;
            }
            _products.Add(inventory);
            return Task.CompletedTask;

        }

        public Task UpdateProductAsync(Product inventory)
        {
            if(_products.Any(x => x.ProductId != inventory.ProductId 
                                && x.ProductName.Equals(inventory.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }
            var productToUpdate = _products.FirstOrDefault(x => x.ProductId == inventory.ProductId);
            if(productToUpdate != null)
            {
                productToUpdate.ProductName = inventory.ProductName;
                productToUpdate.Quantity = inventory.Quantity;
                productToUpdate.Price = inventory.Price;
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_products);
            return _products.Where(x => x.ProductName.Contains(name,StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            #pragma warning disable CS8603 // Possible null reference return.
            return await Task.FromResult(product);
            #pragma warning restore CS8603 // Possible null reference return.
        }

        public  Task RemoveProductAsync(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
