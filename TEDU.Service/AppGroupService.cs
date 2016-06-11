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

        IEnumerable<AppGroup> GetAll();

        AppGroup Add(AppGroup appGroup);

        void Update(AppGroup appGroup);

        AppGroup Delete(int id);

        bool AddUserToGroups(IEnumerable<AppUserGroup> groups, string userId);

        IEnumerable<AppGroup> GetListGroupByUserId(string userId);

        void Save();
    }

    public class AppGroupService : IAppGroupService
    {
        private IAppGroupRepository _appGroupRepository;
        private IUnitOfWork _unitOfWork;
        private IAppUserGroupRepository _appUserGroupRepository;

        public AppGroupService(IUnitOfWork unitOfWork,
            IAppUserGroupRepository appUserGroupRepository,
            IAppGroupRepository appGroupRepository)
        {
            this._appGroupRepository = appGroupRepository;
            this._appUserGroupRepository = appUserGroupRepository;
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

        public IEnumerable<AppGroup> GetAll()
        {
            return _appGroupRepository.GetAll();
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

        public bool AddUserToGroups(IEnumerable<AppUserGroup> userGroups, string userId)
        {
            _appUserGroupRepository.DeleteMulti(x => x.UserId == userId);
            foreach (var userGroup in userGroups)
            {
                _appUserGroupRepository.Add(userGroup);
            }
            return true;
        }

        public IEnumerable<AppGroup> GetListGroupByUserId(string userId)
        {
            return _appGroupRepository.GetListGroupByUserId(userId);
        }
    }
}