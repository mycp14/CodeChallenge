using WebAPI.DbMigrator.DbContext;
using WebAPI.EFCore;

namespace WebAPI.Repository
{
    public interface IPizzaTypeRepository : IRepository<PizzaType>
    {

    }

    public class PizzaTypeRepository : RepositoryBase<PizzaType>, IPizzaTypeRepository
    {
        public PizzaTypeRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}