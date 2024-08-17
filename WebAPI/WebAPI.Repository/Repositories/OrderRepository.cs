using WebAPI.DbMigrator.DbContext;
using WebAPI.EFCore;

namespace WebAPI.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {

    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}