using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public class TechLineRepository : RepositoryBase<TechLine>, ITechLineRepository
    {
        public TechLineRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface ITechLineRepository : IRepository<TechLine>
    {
    }
}
