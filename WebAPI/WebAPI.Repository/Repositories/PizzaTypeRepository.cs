using WebAPI.DbMigrator.DbContext;
using WebAPI.EFCore;

namespace WebAPI.Repository
{
    public interface IPizzaTypeeRepository : IRepository<PizzaType>
    {

    }

    public class PizzaTypeRepository : RepositoryBase<PizzaType>, IPizzaTypeeRepository
    {
        public PizzaTypeRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}