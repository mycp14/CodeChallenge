using WebAPI.DbMigrator.DbContext;
using WebAPI.EFCore;

namespace WebAPI.Repository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {

    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}