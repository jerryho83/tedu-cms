using System.Collections.Generic;
using System.Linq;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface ITechLineService
    {
        TechLine GetDetail(int id);

        IEnumerable<TechLine> GetAll(int page, int pageSize, out int totalRow, string filter);

        IEnumerable<TechLine> GetAll();

        TechLine Add(TechLine TechLine);

        void Update(TechLine TechLine);

        TechLine Delete(int id);

        void AddCourseTechLine(IEnumerable<CourseTechLine> courseTechlines, int courseId);

        IEnumerable<TechLine> GetListByCourseId(int courseId);

        void Save();
    }

    public class TechLineService : ITechLineService
    {
        private ITechLineRepository _techLineRepository;
        private IUnitOfWork _unitOfWork;
        private ICourseTechLineRepository _courseTechLineRepository;

        public TechLineService(ITechLineRepository techLineRepository, ICourseTechLineRepository courseTechLineRepository, IUnitOfWork unitOfWork)
        {
            _techLineRepository = techLineRepository;
            _courseTechLineRepository = courseTechLineRepository;
            _unitOfWork = unitOfWork;
        }

        public TechLine Add(TechLine techLine)
        {
            return _techLineRepository.Add(techLine);
        }

        public void AddCourseTechLine(IEnumerable<CourseTechLine> courseTechlines, int courseId)
        {
            foreach (var item in courseTechlines)
            {
                _courseTechLineRepository.Add(item);
            }
        }

        public TechLine Delete(int id)
        {
            var techLine = _techLineRepository.GetSingleById(id);
            return _techLineRepository.Delete(techLine);
        }

        public IEnumerable<TechLine> GetAll()
        {
            return _techLineRepository.GetAll();
        }

        public IEnumerable<TechLine> GetAll(int page, int pageSize, out int totalRow, string filter)
        {
            var query = _techLineRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);
        }

        public TechLine GetDetail(int id)
        {
            return _techLineRepository.GetSingleById(id);
        }

        public IEnumerable<TechLine> GetListByCourseId(int courseId)
        {
            return _techLineRepository.GetMulti(x => x.CourseTechLines.Any(y => y.CourseId == courseId)
            , new string[] { "CourseCourseTechLines" });
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TechLine techLine)
        {
            _techLineRepository.Update(techLine);
        }
    }
}