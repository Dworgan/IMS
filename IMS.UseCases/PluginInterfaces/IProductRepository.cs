using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<Product> GetProductByIdAsync(int productId);
        Task RemoveProductAsync(int productId);
    }
}
