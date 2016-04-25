using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public class EbookRepository : RepositoryBase<Ebook>, IEbookRepository
    {
        public EbookRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface IEbookRepository : IRepository<Ebook>
    {
    }
}