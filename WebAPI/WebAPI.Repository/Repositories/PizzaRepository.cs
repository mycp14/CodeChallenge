using WebAPI.DbMigrator.DbContext;
using WebAPI.EFCore;

namespace WebAPI.Repository
{
    public interface IPizzaRepository : IRepository<Pizza>
    {

    }

    public class PizzaRepository : RepositoryBase<Pizza>, IPizzaRepository
    {
        public PizzaRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}