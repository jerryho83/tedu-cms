using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface IPageRepository : IRepository<Page>
    {
    }
}