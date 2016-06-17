using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface ITrainerService
    {
        IEnumerable<Trainer> GetAll();

        IEnumerable<Trainer> GetTop(int top);

        IEnumerable<Trainer> GetAll(int page, int pageSize, out int totalRow, string filter = null);

        Trainer Get(int id);

        void Create(Trainer trainer);

        void Update(Trainer trainer);

        void Delete(Trainer trainer);

        void Save();
    }
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrainerService(ITrainerRepository trainerRepository, IUnitOfWork unitOfWork)
        {
            this._trainerRepository = trainerRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Create(Trainer trainer)
        {
            _trainerRepository.Add(trainer);
        }

        public void Delete(Trainer trainer)
        {
            _trainerRepository.Delete(trainer);
        }

        public Trainer Get(int id)
        {
            return _trainerRepository.GetSingleById(id);
        }

        public IEnumerable<Trainer> GetAll()
        {
            return _trainerRepository.GetAll();
        }

        public IEnumerable<Trainer> GetAll(int page, int pageSize, out int totalRow, string filter = null)
        {
            var query = _trainerRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.Name.Contains(filter));
            }
            totalRow = query.Count();
            return query.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<Trainer> GetTop(int top)
        {
            return _trainerRepository.GetAll().Take(top);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Trainer trainer)
        {
            _trainerRepository.Update(trainer);
        }
    }
}
