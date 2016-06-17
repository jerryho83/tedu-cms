using System.Collections.Generic;
using System.Linq;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface ICourseVideoService
    {
        IEnumerable<CourseVideo> GetCourseVideos(int courseId);

        IEnumerable<CourseVideo> GetCourseVideos(int page, int pageSize, out int totalRow, string filter = null);

        IEnumerable<CourseVideo> GetCourseVideos(int courseId, int page, int pageSize, out int totalRow, string filter = null);

        CourseVideo GetCourseVideo(int id);

        CourseVideo CreateCourseVideo(CourseVideo courseVideo);

        void UpdateCourseVideo(CourseVideo courseVideo);

        void Delete(CourseVideo courseVideo);

        void SaveCourseVideo();

        IEnumerable<CourseVideo> GetListByCourseId(int courseId, int page, int pageSize, out int totalRow);
    }

    public class CourseVideoService : ICourseVideoService
    {
        private ICourseVideoRepository _courseVideoRepository;
        private IUnitOfWork _unitOfWork;

        public CourseVideoService(ICourseVideoRepository courseVideoRepository, IUnitOfWork unitOfWork)
        {
            _courseVideoRepository = courseVideoRepository;
            _unitOfWork = unitOfWork;
        }

        public CourseVideo CreateCourseVideo(CourseVideo courseVideo)
        {
            return _courseVideoRepository.Add(courseVideo);
        }

        public void Delete(CourseVideo courseVideo)
        {
            _courseVideoRepository.Delete(courseVideo);
        }

        public CourseVideo GetCourseVideo(int id)
        {
            return _courseVideoRepository.GetSingleById(id);
        }

        public IEnumerable<CourseVideo> GetCourseVideos(int courseId)
        {
            return _courseVideoRepository.GetMulti(x => x.CourseId == courseId && x.Status).OrderBy(x => x.DisplayOrder);
        }

        public IEnumerable<CourseVideo> GetCourseVideos(int page, int pageSize, out int totalRow, string filter = null)
        {
            IQueryable<CourseVideo> model = _courseVideoRepository.GetMulti(x => x.Status).OrderBy(x => x.DisplayOrder);
            if (!string.IsNullOrEmpty(filter))
            {
                model = model.Where(x => x.Name.Contains(filter));
            }
            totalRow = model.Count();
            return model.Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<CourseVideo> GetCourseVideos(int courseId, int page, int pageSize, out int totalRow, string filter = null)
        {
            IQueryable<CourseVideo> model = _courseVideoRepository.GetMulti(x => x.Status && x.CourseId == courseId).OrderBy(x => x.DisplayOrder);
            if (!string.IsNullOrEmpty(filter))
            {
                model = model.Where(x => x.Name.Contains(filter));
            }
            totalRow = model.Count();
            return model.Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<CourseVideo> GetListByCourseId(int courseId, int page, int pageSize, out int totalRow)
        {
            IQueryable<CourseVideo> model = _courseVideoRepository.GetMulti(x => x.Status && x.CourseId == courseId).OrderBy(x => x.DisplayOrder);
            totalRow = model.Count();
            return model.Skip(page * pageSize).Take(pageSize);
        }

        public void SaveCourseVideo()
        {
            _unitOfWork.Commit();
        }

        public void UpdateCourseVideo(CourseVideo courseVideo)
        {
            _courseVideoRepository.Update(courseVideo);
        }
    }
}