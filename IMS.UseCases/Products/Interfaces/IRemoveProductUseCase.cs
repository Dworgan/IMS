namespace IMS.UseCases.Products.Interfaces
{
    public interface IRemoveProductUseCase
    {
        Task ExecuteAsync(int productId);
    }
}