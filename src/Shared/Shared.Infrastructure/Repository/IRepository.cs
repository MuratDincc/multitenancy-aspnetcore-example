using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Shared.Infrastructure.Repository;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();

    IEnumerable<T> Find(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

    T GetById(object id);

    void Insert(T obj);
    void Update(T obj);
    void Delete(object id);
    void Save();
}