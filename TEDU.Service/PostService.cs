using System;
using System.Collections.Generic;
using System.Linq;
using TEDU.Common;
using TEDU.Common.Helper;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model;
using TEDU.Model.Models;

namespace TEDU.Service
{
    // operations you want to expose
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();

        IEnumerable<Post> GetPosts(int page, int pageSize, out int totalRow, string filter = null);

        Post GetPost(int id);

        void CreatePost(Post Post);

        void UpdatePost(Post Post);

        void Delete(Post post);

        void SavePost();

        IEnumerable<Post> GetRecentPosts(int top);

        IEnumerable<Post> GetPopularPosts(int top);

        IEnumerable<Post> GetBreakingNews(int top);

        List<Post> GetRecentPostsByCategory(int categoryId, int top);

        List<Post> GetListByCategoryAlias(string categoryAlias, int page, int pageSize, out int totalRow);

        IEnumerable<Post> GetPostSlide(int top);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository PostsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IPostTagRepository postTagRepository;
        private readonly ITagRepository tagRepository;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IPostRepository PostsRepository,
            ICategoryRepository categoryRepository,
            IPostTagRepository postTagRepository,
            ITagRepository tagRepository,
            IUnitOfWork unitOfWork)
        {
            this.PostsRepository = PostsRepository;
            this.categoryRepository = categoryRepository;
            this.postTagRepository = postTagRepository;
            this.tagRepository = tagRepository;
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
                    m.Status == StatusEnum.Publish.ToString())
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = PostsRepository
                    .GetMany(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()) &&
                    m.Status == StatusEnum.Publish.ToString())
                    .Count();
            }
            else
            {
                model = PostsRepository
                    .GetMany(x => x.Status == StatusEnum.Publish.ToString())
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = PostsRepository.GetMany(x => x.Status == StatusEnum.Publish.ToString()).Count();
            }

            return model;
        }

        public Post GetPost(int id)
        {
            var Post = PostsRepository.Get(x => x.ID == id, new string[] { "Category" });
            return Post;
        }

        public void CreatePost(Post Post)
        {
            PostsRepository.Add(Post);

            if (!string.IsNullOrEmpty(Post.Tags))
            {
                string[] tags = Post.Tags.Split(',');
                foreach (var item in tags)
                {
                    string alias = StringHelper.ToUnsignString(item);
                    if (tagRepository.Count(x => x.ID == alias) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = alias;
                        tag.Name = item;
                        tagRepository.Add(tag);
                    }

                    PostTag postTag = new PostTag();
                    postTag.PostID = Post.ID;
                    postTag.TagID = alias;
                    postTagRepository.Add(postTag);
                }
            }
        }

        public void UpdatePost(Post postEntity)
        {
            PostsRepository.Update(postEntity);

            if (!string.IsNullOrEmpty(postEntity.Tags))
            {
                string[] tags = postEntity.Tags.Split(',');
                foreach (var item in tags)
                {
                    string alias = StringHelper.ToUnsignString(item);
                    if (tagRepository.Count(x => x.ID == alias) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = alias;
                        tag.Name = item;
                        tagRepository.Add(tag);
                    }
                    postTagRepository.Delete(x => x.PostID == postEntity.ID);

                    PostTag postTag = new PostTag();
                    postTag.PostID = postEntity.ID;
                    postTag.TagID = alias;
                    postTagRepository.Add(postTag);
                }
            }
        }

        public void SavePost()
        {
            unitOfWork.Commit();
        }

        public void Delete(Post post)
        {
            PostsRepository.Delete(post);
        }

        public IEnumerable<Post> GetRecentPosts(int top = 0)
        {
            return PostsRepository.Filter(x => x.Status == StatusEnum.Publish.ToString(), new string[] { "Category" })
                .OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Post> GetPopularPosts(int top)
        {
            return PostsRepository
                .Filter(x => x.Status == StatusEnum.Publish.ToString(), new string[] { "Category" })
                .OrderByDescending(x => x.ViewCount).Take(top);
        }

        public IEnumerable<Post> GetBreakingNews(int top)
        {
            return PostsRepository
               .Filter(x => x.Status == StatusEnum.Publish.ToString() && x.HotFlag.HasValue, new string[] { "Category" })
               .OrderByDescending(x => x.HotFlag).Take(top);
        }

        public IEnumerable<Post> GetPostSlide(int top)
        {
            return PostsRepository
               .Filter(x => x.Status == StatusEnum.Publish.ToString() && x.SlideFlag.HasValue, new string[] { "Category" })
               .OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public List<Post> GetRecentPostsByCategory(int categoryId, int top)
        {
            return PostsRepository
                .GetMany(x => x.Status == StatusEnum.Publish.ToString() && x.CategoryID == categoryId)
                .OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Post> GetListByCategoryAlias(string categoryAlias, int page, int pageSize, out int totalRow)
        {
            var model = PostsRepository
                    .Filter(m => m.Category.Alias == categoryAlias &&
                    m.Status == StatusEnum.Publish.ToString(), new string[] { "Category" })
                    .OrderBy(m => m.ID)
                    .Skip((page-1) * pageSize)
                    .Take(pageSize)
                    .ToList();

            totalRow = PostsRepository
               .GetMany(m => m.Category.Alias == categoryAlias &&
                    m.Status == StatusEnum.Publish.ToString())
                .Count();
            return model;
        }

        #endregion IPostService Members
    }
}