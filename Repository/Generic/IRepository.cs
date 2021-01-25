using System.Collections.Generic;
using lyncas.Model.Base;

namespace lyncas.Repository.Generic
{
  public interface IRepository<T> where T : BaseEntity
  {
    T Create(T item);
    List<T> FindAll();
    void Delete(int id);

  }
}