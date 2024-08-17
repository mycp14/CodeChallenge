using WebAPI.DbMigrator.DbContext;

namespace WebAPI.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private WebAPIDbContext? dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public WebAPIDbContext DbContext
        {
            get { return dbContext ??= dbFactory.Init(); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }

        public async Task CommitAsync()
        {
            await DbContext.CommitAsync();
        }
    }
}