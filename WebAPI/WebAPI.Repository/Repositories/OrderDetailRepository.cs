using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.DbMigrator.DbContext;
using WebAPI.EFCore;

namespace WebAPI.Repository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailsWithPaginationIncludeOrderAndPizza(int page, int pageSize);
        Task<IEnumerable<OrderDetail>> GetManyOrderDetailsIncludeOrderAndPizza(Expression<Func<OrderDetail, bool>> where);
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory) { }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsWithPaginationIncludeOrderAndPizza(int page, int pageSize)
        {
            return await dbSet.Skip((page - 1) * pageSize).Take(pageSize).Include(x => x.Order).Include(x => x.Pizza).ThenInclude(x => x.PizzaType).ToListAsync();
        }
        public async Task<IEnumerable<OrderDetail>> GetManyOrderDetailsIncludeOrderAndPizza(Expression<Func<OrderDetail, bool>> where)
        {
            return await dbSet.Where(where).Include(x => x.Order).Include(x => x.Pizza).ThenInclude(x => x.PizzaType).ToListAsync();
        }
    }
}