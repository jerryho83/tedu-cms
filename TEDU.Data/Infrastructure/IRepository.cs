using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        T GetById(int id);
        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);
        // Gets all entities of type T
        IEnumerable<T> GetAll();
        // Gets entities using delegate
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        int Count(Expression<Func<T, bool>> where);
        IQueryable<T> All(string[] includes = null);

        T Get(Expression<Func<T, bool>> expression, string[] includes = null);

        T Find(Expression<Func<T, bool>> predicate, string[] includes = null);

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null);

        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        bool Contains(Expression<Func<T, bool>> predicate);
    }
}
