using System.Collections.Generic;
using System.Linq;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface IPageService
    {
        IEnumerable<Page> GetPagesPaging(int page, int pageSize, out int totalRow, string filter = null);

        Page GetPage(int id);

        void Create(Page page);

        void Delete(Page page);

        void Update(Page page);

        void Save();
    }

    public class PageService : IPageService
    {
        private readonly IPageRepository pageRepository;
        private readonly IUnitOfWork unitOfWork;

        public PageService(IPageRepository pageRepository, IUnitOfWork unitOfWork)
        {
            this.pageRepository = pageRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(Page page)
        {
            pageRepository.Add(page);
        }

        public void Delete(Page page)
        {
            pageRepository.Delete(page);
        }

        public Page GetPage(int id)
        {
            return pageRepository.GetSingleById(id);
        }

        public IEnumerable<Page> GetPagesPaging(int page, int pageSize, out int totalRow, string filter = null)
        {
            IEnumerable<Page> model;
            if (!string.IsNullOrEmpty(filter))
            {
                model = pageRepository
                    .GetMulti(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()) &&
                    m.Status)
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = pageRepository
                    .GetMulti(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()) &&
                    m.Status)
                    .Count();
            }
            else
            {
                model = pageRepository
                    .GetMulti(x => x.Status)
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = pageRepository.GetMulti(x => x.Status).Count();
            }

            return model;
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(Page page)
        {
            pageRepository.Update(page);
        }
    }
}