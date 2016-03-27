using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Common;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model;

namespace TEDU.Service
{
    // operations you want to expose
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetPosts(int page, int pageSize, out int totalRow, string filter = null);
        Post GetPost(int id);
        void CreatePost(Post Post);
        void Delete(Post post);
        void SavePost();
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository PostsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IPostRepository PostsRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.PostsRepository = PostsRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IPostService Members

        public IEnumerable<Post> GetPosts()
        {
            var Posts = PostsRepository.GetAll();
            return Posts;
        }

        public IEnumerable<Post> GetPosts(int page, int pageSize, out int totalRow, string filter = null)
        {
            IEnumerable<Post> model;
            if (!string.IsNullOrEmpty(filter))
            {
                model = PostsRepository
                    .GetMany(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()) &&
                    m.Status==StatusEnum.Publish.ToString())
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = PostsRepository
                    .GetMany(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()) &&
                    m.Status==StatusEnum.Publish.ToString())
                    .Count();
            }
            else
            {
                model = PostsRepository
                    .GetMany(x => x.Status== StatusEnum.Publish.ToString())
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = PostsRepository.GetMany(x => x.Status==StatusEnum.Publish.ToString()).Count();
            }

            return model;
        }

        public Post GetPost(int id)
        {
            var Post = PostsRepository.GetById(id);
            return Post;
        }

        public void CreatePost(Post Post)
        {
            PostsRepository.Add(Post);
        }

        public void SavePost()
        {
            unitOfWork.Commit();
        }

        public void Delete(Post post)
        {
            PostsRepository.Delete(post);
        }

        #endregion

    }
}
