
namespace WebAPI.Services
{
    public interface IImportService
    {
        Task ImportPizzaType(Stream fileStream);
        Task ImportPizzas(Stream fileStream);
        Task ImportOrders(Stream fileStream);
        Task ImportOrderDetails(Stream fileStream);
    }
}