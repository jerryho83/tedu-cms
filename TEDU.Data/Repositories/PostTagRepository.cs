using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface IPostTagRepository : IRepository<PostTag>
    {
    }
}