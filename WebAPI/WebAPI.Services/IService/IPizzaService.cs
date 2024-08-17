
using WebAPI.EFCore;

namespace WebAPI.Services
{
    public interface IPizzaService
    {
        Task<List<PizzaTypeVM>> GetAllPizzaTypes();
        Task<List<PizzaVM>> GetAllPizzas();
        Task<PizzaTypeVM> GetPizzaTypeById(string id);
        Task<PizzaVM> GetPizzaById(string id);
    }
}