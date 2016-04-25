using System;
using System.Collections.Generic;
using System.Linq;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface IEbookService
    {
        IEnumerable<Ebook> GetEbookPaging(int page, int pageSize, out int totalRow, string filter = null);

        Ebook GetEbook(int id);

        void Create(Ebook ebook);

        void Delete(Ebook ebook);

        void Update(Ebook ebook);

        void Save();
    }

    public class EbookService : IEbookService
    {
        private readonly IEbookRepository ebookRepository;
        private readonly IUnitOfWork unitOfWork;

        public EbookService(IEbookRepository ebookRepository, IUnitOfWork unitOfWork)
        {
            this.ebookRepository = ebookRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(Ebook ebook)
        {
            ebookRepository.Add(ebook);
        }

        public void Delete(Ebook ebook)
        {
            ebookRepository.Delete(ebook);
        }

        public Ebook GetEbook(int id)
        {
            var ebook = ebookRepository.GetById(id);
            return ebook;
        }

        public IEnumerable<Ebook> GetEbookPaging(int page, int pageSize, out int totalRow, string filter = null)
        {
            IEnumerable<Ebook> model;
            if (!string.IsNullOrEmpty(filter))
            {
                model = ebookRepository
                    .GetMany(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()) &&
                    m.Status)
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = ebookRepository
                    .GetMany(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()) &&
                    m.Status)
                    .Count();
            }
            else
            {
                model = ebookRepository
                    .GetMany(x => x.Status)
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = ebookRepository.GetMany(x => x.Status).Count();
            }

            return model;
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(Ebook ebook)
        {
            ebookRepository.Update(ebook);
        }
    }
}