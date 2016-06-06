using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public class VideoCommentRepository : RepositoryBase<VideoComment>, IVideoCommentRepository
    {
        public VideoCommentRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface IVideoCommentRepository : IRepository<VideoComment>
    {
    }
}
