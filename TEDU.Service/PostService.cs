using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model;

namespace TEDU.Service
{
    // operations you want to expose
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetCategoryPosts(string categoryName, string PostName = null);
        Post GetPost(int id);
        void CreatePost(Post Post);
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

        public IEnumerable<Post> GetCategoryPosts(string categoryName, string PostName = null)
        {
            var category = categoryRepository.GetCategoryByName(categoryName);
            return category.Posts.Where(g => g.Name.ToLower().Contains(PostName.ToLower().Trim()));
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

        #endregion

    }
}
