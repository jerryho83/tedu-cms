using System.Collections.Generic;
using System.Linq;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface ICourseUserService
    {
        IEnumerable<CourseUser> GetCourseUsers(int page, int pageSize, out int totalRow, string filter = null);

        IEnumerable<CourseUser> GetCourseUsers(int courseId, int page, int pageSize, out int totalRow, string filter = null);

        CourseUser GetCourseUser(int id);

        CourseUser CreateCourseUser(CourseUser courseUser);

        void UpdateCourseUser(CourseUser courseUser);

        void Delete(CourseUser courseUser);

        void SaveCourseUser();

        IEnumerable<CourseUser> GetListByCourseId(int courseId, int page, int pageSize, out int totalRow);
    }

    public class CourseUserService : ICourseUserService
    {
        private ICourseUserRepository _courseUserRepository;
        private IUnitOfWork _unitOfWork;

        public CourseUserService(ICourseUserRepository courseUserRepository, IUnitOfWork unitOfWork)
        {
            _courseUserRepository = courseUserRepository;
            _unitOfWork = unitOfWork;
        }

        public CourseUser CreateCourseUser(CourseUser courseUser)
        {
            return _courseUserRepository.Add(courseUser);
        }

        public void Delete(CourseUser courseUser)
        {
            _courseUserRepository.Delete(courseUser);
        }

        public CourseUser GetCourseUser(int id)
        {
            return _courseUserRepository.GetSingleById(id);
        }

        public IEnumerable<CourseUser> GetCourseUsers(int page, int pageSize, out int totalRow, string filter = null)
        {
            IQueryable<CourseUser> model = _courseUserRepository.GetMulti(x => x.Status, new string[] { "AppUser" });
            if (!string.IsNullOrEmpty(filter))
            {
                model = model.Where(x => x.AppUser.FullName.Contains(filter));
            }
            totalRow = model.Count();
            return model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<CourseUser> GetCourseUsers(int courseId, int page, int pageSize, out int totalRow, string filter = null)
        {
            IQueryable<CourseUser> model = _courseUserRepository.GetMulti(x => x.Status, new string[] { "AppUser" });
            if (!string.IsNullOrEmpty(filter))
            {
                model = model.Where(x => x.AppUser.FullName.Contains(filter) && x.CourseId == courseId);
            }
            totalRow = model.Count();
            return model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<CourseUser> GetListByCourseId(int courseId, int page, int pageSize, out int totalRow)
        {
            IQueryable<CourseUser> model = _courseUserRepository.GetMulti(x => x.Status && x.CourseId == courseId, new string[] { "AppUser" });
            totalRow = model.Count();
            return model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
        }

        public void SaveCourseUser()
        {
            _unitOfWork.Commit();
        }

        public void UpdateCourseUser(CourseUser courseUser)
        {
            _courseUserRepository.Update(courseUser);
        }
    }
}