namespace WebAPI.DbMigrator.DbContext
{
    public interface IDbFactory : IDisposable
    {
        WebAPIDbContext Init();
    }
    public class DbFactory : Disposable, IDbFactory
    {
        readonly WebAPIDbContext webAPIDbContext;

        public DbFactory(WebAPIDbContext pgContext)
        {
            webAPIDbContext = pgContext;
        }

        public WebAPIDbContext Init()
        {
            return webAPIDbContext;
        }

        protected override void DisposeCore()
        {
            if (webAPIDbContext != null)
                webAPIDbContext.Dispose();
        }
    }
}
