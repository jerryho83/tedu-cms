using TEDU.Data.Infrastructure;
using TEDU.Model;

namespace TEDU.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface IPostRepository : IRepository<Post>
    {
    }
}