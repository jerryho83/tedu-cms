using System;
using System.Collections.Generic;
using System.Linq;
using TEDU.Common;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();

        IEnumerable<Course> GetTopCourses(int top);

        IEnumerable<Course> GetCourses(int page, int pageSize, out int totalRow, string filter = null);

        IEnumerable<Course> GetCourses(int categoryId, int page, int pageSize, out int totalRow, string filter = null);

        Course GetCourse(int id);

        void CreateCourse(Course course);

        void UpdateCourse(Course course);

        void Delete(Course course);

        void SaveCourse();
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this._courseRepository = courseRepository;
            this._unitOfWork = unitOfWork;
        }

        public void CreateCourse(Course course)
        {
            _courseRepository.Add(course);
        }

        public void Delete(Course course)
        {
            _courseRepository.Delete(course);
        }

        public Course GetCourse(int id)
        {
            return _courseRepository.GetSingleById(id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _courseRepository.GetAll();
        }

        public IEnumerable<Course> GetCourses(int page, int pageSize, out int totalRow, string filter = null)
        {
            var query = _courseRepository.GetMulti(x => x.Status == StatusEnum.Publish.ToString());
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.Name.Contains(filter));
            }
            totalRow = query.Count();
            return query.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<Course> GetCourses(int categoryId, int page, int pageSize, out int totalRow, string filter = null)
        {
            var query = _courseRepository.GetMulti(x => x.Status == StatusEnum.Publish.ToString() && x.CategoryId == categoryId);
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.Name.Contains(filter));
            }
            totalRow = query.Count();
            return query.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<Course> GetTopCourses(int top)
        {
            return _courseRepository.GetMulti(x => x.Status == StatusEnum.Publish.ToString() && x.HotFlag == true);
        }

        public void SaveCourse()
        {
            _unitOfWork.Commit();
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }
    }
}