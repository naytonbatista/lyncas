using System.Collections.Generic;
using System.Linq;
using lyncas.Model.Base;
using lyncas.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace lyncas.Repository.Generic
{
  public class GenericRepository<T> : IRepository<T> where T : BaseEntity
  {
    protected Context _context;
    private DbSet<T> _dataSet;

    public GenericRepository(Context context)
    {
      _context = context;
      _dataSet = context.Set<T>();
    }
    public T Create(T item)
    {
      _dataSet.Add(item);
      _context.SaveChanges();
      return item;
    }

    public void Delete(int id)
    {
      var result = _dataSet.SingleOrDefault(p => p.Id == id);

      _dataSet.Remove(result);
      _context.SaveChanges();

    }

    public List<T> FindAll()
    {
      return _dataSet.ToList();
    }
  }
}