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

        List<Post> GetReleatedPosts(int top, int id);

        void IncreaseViewCount(int id);

        List<Tag> GetListTags(int id);

        List<Tag> GetPopularListTags(int top);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _postsRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostTagRepository _postTagRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postsRepository,
            ICategoryRepository categoryRepository,
            IPostTagRepository postTagRepository,
            ITagRepository tagRepository,
            IUnitOfWork unitOfWork)
        {
            this._postsRepository = postsRepository;
            this._categoryRepository = categoryRepository;
            this._postTagRepository = postTagRepository;
            this._tagRepository = tagRepository;
            this._unitOfWork = unitOfWork;
        }

        #region IPostService Members

        public IEnumerable<Post> GetPosts()
        {
            var Posts = _postsRepository.GetAll();
            return Posts;
        }

        public IEnumerable<Post> GetPosts(int page, int pageSize, out int totalRow, string filter = null)
        {
            IEnumerable<Post> model;
            if (!string.IsNullOrEmpty(filter))
            {
                model = _postsRepository
                    .GetMany(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()) &&
                    m.Status == StatusEnum.Publish.ToString())
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = _postsRepository
                    .GetMany(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()) &&
                    m.Status == StatusEnum.Publish.ToString())
                    .Count();
            }
            else
            {
                model = _postsRepository
                    .GetMany(x => x.Status == StatusEnum.Publish.ToString())
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = _postsRepository.GetMany(x => x.Status == StatusEnum.Publish.ToString()).Count();
            }

            return model;
        }

        public Post GetPost(int id)
        {
            var Post = _postsRepository.Get(x => x.ID == id, new string[] { "Category" });
            return Post;
        }

        public void CreatePost(Post Post)
        {
            _postsRepository.Add(Post);

            if (!string.IsNullOrEmpty(Post.Tags))
            {
                string[] tags = Post.Tags.Split(',');
                foreach (var item in tags)
                {
                    string alias = StringHelper.ToUnsignString(item);
                    if (_tagRepository.Count(x => x.ID == alias) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = alias;
                        tag.Name = item;
                        _tagRepository.Add(tag);
                    }

                    PostTag postTag = new PostTag();
                    postTag.PostID = Post.ID;
                    postTag.TagID = alias;
                    _postTagRepository.Add(postTag);
                }
            }
        }

        public void UpdatePost(Post postEntity)
        {
            _postsRepository.Update(postEntity);

            if (!string.IsNullOrEmpty(postEntity.Tags))
            {
                string[] tags = postEntity.Tags.Split(',');
                foreach (var item in tags)
                {
                    string alias = StringHelper.ToUnsignString(item);
                    if (_tagRepository.Count(x => x.ID == alias) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = alias;
                        tag.Name = item;
                        _tagRepository.Add(tag);
                    }
                    _postTagRepository.Delete(x => x.PostID == postEntity.ID);

                    PostTag postTag = new PostTag();
                    postTag.PostID = postEntity.ID;
                    postTag.TagID = alias;
                    _postTagRepository.Add(postTag);
                }
            }
        }

        public void SavePost()
        {
            _unitOfWork.Commit();
        }

        public void Delete(Post post)
        {
            _postsRepository.Delete(post);
        }

        public IEnumerable<Post> GetRecentPosts(int top = 0)
        {
            return _postsRepository.Filter(x => x.Status == StatusEnum.Publish.ToString(), new string[] { "Category" })
                .OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Post> GetPopularPosts(int top)
        {
            return _postsRepository
                .Filter(x => x.Status == StatusEnum.Publish.ToString(), new string[] { "Category" })
                .OrderByDescending(x => x.ViewCount).Take(top);
        }

        public IEnumerable<Post> GetBreakingNews(int top)
        {
            return _postsRepository
               .Filter(x => x.Status == StatusEnum.Publish.ToString() && x.HotFlag.HasValue, new string[] { "Category" })
               .OrderByDescending(x => x.HotFlag).Take(top);
        }

        public IEnumerable<Post> GetPostSlide(int top)
        {
            return _postsRepository
               .Filter(x => x.Status == StatusEnum.Publish.ToString() && x.SlideFlag.HasValue, new string[] { "Category" })
               .OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public List<Post> GetRecentPostsByCategory(int categoryId, int top)
        {
            return _postsRepository
                .GetMany(x => x.Status == StatusEnum.Publish.ToString() && x.CategoryID == categoryId)
                .OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Post> GetListByCategoryAlias(string categoryAlias, int page, int pageSize, out int totalRow)
        {
            var model = _postsRepository
                    .Filter(m => m.Category.Alias == categoryAlias &&
                    m.Status == StatusEnum.Publish.ToString(), new string[] { "Category" })
                    .OrderBy(m => m.ID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

            totalRow = _postsRepository
               .GetMany(m => m.Category.Alias == categoryAlias &&
                    m.Status == StatusEnum.Publish.ToString())
                .Count();
            return model;
        }

        public void IncreaseViewCount(int id)
        {
            var post = _postsRepository.GetById(id);
            post.ViewCount += 1;
            _postsRepository.Update(post);

        }

        public List<Tag> GetListTags(int id)
        {
            return _postTagRepository
                .Filter(x => x.PostID == id, new string[] { "Tag" })
                .Select(x => x.Tag).ToList();
        }

        public List<Post> GetReleatedPosts(int top, int id)
        {
            var post = _postsRepository.GetById(id);
            return _postsRepository
             .Filter(x => x.Status == StatusEnum.Publish.ToString() && x.ID != id && x.CategoryID == post.ID, new string[] { "Category" })
             .OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Tag> GetPopularListTags(int top)
        {
            var list = _tagRepository.All(new string[] { "PostTags" });

            var list1 =    list.Select(x => new { ID = x.ID, Name = x.Name, Count = x.PostTags.Count() })
                .GroupBy(a => new { a.ID, a.Name })
                .SelectMany(g => g.OrderByDescending(grp => grp.Count))
                .Take(top)
                .Select(y => new Tag { ID = y.ID, Name = y.Name });
            return list.ToList();
        }
        #endregion IPostService Members
    }
}