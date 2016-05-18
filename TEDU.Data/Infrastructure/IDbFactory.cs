using System;

namespace TEDU.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        TeduDbContext Init();
    }
}