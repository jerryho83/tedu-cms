using System.Collections.Generic;
using System.Linq;
using TEDU.Common.Exceptions;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface IAppRoleService
    {
        AppRole GetDetail(string id);

        IEnumerable<AppRole> GetAll(int page, int pageSize, out int totalRow, string filter);

        AppRole Add(AppRole AppRole);

        void Update(AppRole AppRole);

        void Delete(string id);

        void Save();
    }

    public class AppRoleService : IAppRoleService
    {
        private IAppRoleRepository _appRoleRepository;
        private IUnitOfWork _unitOfWork;

        public AppRoleService(IUnitOfWork unitOfWork, IAppRoleRepository AppRoleRepository)
        {
            this._appRoleRepository = AppRoleRepository;
            this._unitOfWork = unitOfWork;
        }

        public AppRole Add(AppRole AppRole)
        {
            if (_appRoleRepository.CheckContains(x => x.Name == AppRole.Name))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appRoleRepository.Add(AppRole);
        }

        public void Delete(string id)
        {
            _appRoleRepository.DeleteMulti(x=>x.Id==id);
        }

        public IEnumerable<AppRole> GetAll(int page, int pageSize, out int totalRow, string filter = null)
        {
            var query = _appRoleRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);
        }

        public AppRole GetDetail(string id)
        {
            return _appRoleRepository.GetSingleByCondition(x => x.Id == id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(AppRole AppRole)
        {
            if (_appRoleRepository.CheckContains(x => x.Name == AppRole.Name && x.Id != AppRole.Id))
                throw new NameDuplicatedException("Tên không được trùng");
            _appRoleRepository.Update(AppRole);
        }
    }
}