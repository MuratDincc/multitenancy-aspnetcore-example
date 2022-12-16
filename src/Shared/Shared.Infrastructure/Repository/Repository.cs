using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Shared.Domain.Entities;
using Shared.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace Shared.Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly DbContext _context;
    private DbSet<T> _table = null;

    public Repository(DbContext context)
    {
        this._context = context;
        this._table = _context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _table.ToList();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        IQueryable<T> query = _table;

        if (expression != null)
        {
            query = query.Where(expression);
        }

        if (include != null)
            query = include(query);

        return query.AsEnumerable();
    }

    public T GetById(object id)
    {
        return _table.Find(id);
    }

    public void Insert(T obj)
    {
        _table.Add(obj);
    }

    public void Update(T obj)
    {
        _table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
    }

    public void Delete(object id)
    {
        T existing = _table.Find(id);
        _table.Remove(existing);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}