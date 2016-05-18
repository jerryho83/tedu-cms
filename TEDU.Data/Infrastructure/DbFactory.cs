namespace TEDU.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private TeduDbContext dbContext;

        public TeduDbContext Init()
        {
            return dbContext ?? (dbContext = new TeduDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}