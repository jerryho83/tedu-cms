using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface IAppGroupService
    {
        AppGroup GetDetail(int id);

        AppGroup Add(AppGroup appGroup);

        void Update(AppGroup appGroup);

        AppGroup Delete(int id);

        void Save();
    }

    public class AppGroupService : IAppGroupService
    {
        private IAppGroupRepository _appGroupRepository;
        private IUnitOfWork _unitOfWork;

        public AppGroupService(IUnitOfWork unitOfWork, IAppGroupRepository appGroupRepository)
        {
            this._appGroupRepository = appGroupRepository;
            this._unitOfWork = unitOfWork;
        }

        public AppGroup Add(AppGroup appGroup)
        {
            return _appGroupRepository.Add(appGroup);
        }

        public AppGroup Delete(int id)
        {
            var appGroup = this._appGroupRepository.GetSingleById(id);
            return _appGroupRepository.Delete(appGroup);
        }

        public AppGroup GetDetail(int id)
        {
            return _appGroupRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(AppGroup appGroup)
        {
            _appGroupRepository.Update(appGroup);
        }
    }
}