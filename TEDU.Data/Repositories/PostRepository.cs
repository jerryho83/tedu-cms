using System.Collections.Generic;
using TEDU.Data.Infrastructure;
using TEDU.Model;
using System.Linq;

namespace TEDU.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
        public IEnumerable<Post> GetListPostByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagID == tagId
                        select p;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }

    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetListPostByTag(string tagId, int page, int pageSize, out int totalRow);
        
    }
}