using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedu.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        TeduContext dbContext;

        public TeduContext Init()
        {
            return dbContext ?? (dbContext = new TeduContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
