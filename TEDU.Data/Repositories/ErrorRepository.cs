using TEDU.Data.Infrastructure;
using TEDU.Model;

namespace TEDU.Data.Repositories
{
    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface IErrorRepository : IRepository<Error>
    {
    }
}