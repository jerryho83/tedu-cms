using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        TEDUEntities dbContext;

        public TEDUEntities Init()
        {
            return dbContext ?? (dbContext = new TEDUEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
