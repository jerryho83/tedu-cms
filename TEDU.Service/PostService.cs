﻿using System.Collections.Generic;
using System.Linq;
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

        IEnumerable<Post> GetRecentPosts(int top);

        IEnumerable<Post> GetPopularPosts(int top);

        IEnumerable<Post> GetBreakingNews(int top);
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

        public IEnumerable<Post> GetRecentPosts(int top = 0)
        {
            return PostsRepository
                .GetMany(x => x.Status == StatusEnum.Publish.ToString())
                .OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Post> GetPopularPosts(int top)
        {
            return PostsRepository
                .GetMany(x => x.Status == StatusEnum.Publish.ToString())
                .OrderByDescending(x => x.ViewCount).Take(top);
        }

        public IEnumerable<Post> GetBreakingNews(int top)
        {
            return PostsRepository
               .GetMany(x => x.Status == StatusEnum.Publish.ToString() && x.HotFlag.HasValue)
               .OrderByDescending(x => x.HotFlag).Take(top);
        }

        #endregion IPostService Members
    }
}