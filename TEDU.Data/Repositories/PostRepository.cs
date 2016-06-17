using System.Collections.Generic;
using TEDU.Data.Infrastructure;
using TEDU.Model;
using System.Linq;
using System.Data.Entity;
using TEDU.Model.Models;

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
                        join c in DbContext.Categories
                        on p.CategoryID equals c.ID
                        where pt.TagID == tagId
                        select new
                        {
                            ID = p.ID,
                            Alias = p.Alias,
                            Name = p.Name,
                            Category  = c,
                            Description = p.Description,
                            CreatedDate = p.CreatedDate,
                            ViewCount = p.ViewCount,
                            Image = p.Image
                        };
            totalRow = query.Count();

            return (IEnumerable<Post>)query.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }

    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetListPostByTag(string tagId, int page, int pageSize, out int totalRow);

    }
}