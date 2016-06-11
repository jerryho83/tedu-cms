using System;
using System.Collections.Generic;
using System.Linq;
using TEDU.Common.Exceptions;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface IAppGroupService
    {
        AppGroup GetDetail(int id);

        IEnumerable<AppGroup> GetAll(int page, int pageSize, out int totalRow, string filter);

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
            if (_appGroupRepository.CheckContains(x => x.Name == appGroup.Name))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appGroupRepository.Add(appGroup);
        }

        public AppGroup Delete(int id)
        {
            var appGroup = this._appGroupRepository.GetSingleById(id);
            return _appGroupRepository.Delete(appGroup);
        }

        public IEnumerable<AppGroup> GetAll(int page, int pageSize, out int totalRow, string filter = null)
        {
            var query = _appGroupRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);
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
            if (_appGroupRepository.CheckContains(x => x.Name == appGroup.Name && x.Id != appGroup.Id))
                throw new NameDuplicatedException("Tên không được trùng");
            _appGroupRepository.Update(appGroup);
        }
    }
}