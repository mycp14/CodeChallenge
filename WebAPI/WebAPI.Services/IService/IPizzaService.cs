
using WebAPI.EFCore;

namespace WebAPI.Services
{
    public interface IPizzaService
    {
        Task<List<PizzaTypeVM>> GetAllPizzaTypes();
    }
}