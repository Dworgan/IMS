using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Products
{
    public class RemoveProductUseCase : IRemoveProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public RemoveProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task ExecuteAsync(int productId)
        {
            await _productRepository.RemoveProductAsync(productId);
        }
    }
}
