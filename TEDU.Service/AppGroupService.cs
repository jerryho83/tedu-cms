using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface IAppGroupService
    {
        AppGroup GetDetail(int id);
        AppGroup Add(AppGroup appGroup);
        AppGroup Update(AppGroup appGroup);
        AppGroup Delete(int id);
        void Save();

    }
    public class AppGroupService : IAppGroupService
    {
        public AppGroup Add(AppGroup appGroup)
        {
            throw new NotImplementedException();
        }

        public AppGroup Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AppGroup GetDetail(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public AppGroup Update(AppGroup appGroup)
        {
            throw new NotImplementedException();
        }
    }
}
