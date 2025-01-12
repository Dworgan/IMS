namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IRemoveInventoryUseCase
    {
        Task ExecuteAsync(int inventoryId);
    }
}