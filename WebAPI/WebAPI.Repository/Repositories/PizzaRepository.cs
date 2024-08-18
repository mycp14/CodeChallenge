using Microsoft.EntityFrameworkCore;
using WebAPI.DbMigrator.DbContext;
using WebAPI.EFCore;

namespace WebAPI.Repository
{
    public interface IPizzaRepository : IRepository<Pizza>
    {
        Task<IEnumerable<Pizza>> GetPizzaIncludePizzaType();
    }

    public class PizzaRepository : RepositoryBase<Pizza>, IPizzaRepository
    {
        public PizzaRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public async Task<IEnumerable<Pizza>> GetPizzaIncludePizzaType()
        {
            return await dbSet.Include(x => x.PizzaType).ToListAsync();
        }
    }
}