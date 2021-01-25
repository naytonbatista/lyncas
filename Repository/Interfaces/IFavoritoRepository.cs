using lyncas.Model;
using lyncas.Repository.Generic;

namespace lyncas.Repository.Interfaces
{
  public interface IFavoritoRepository : IRepository<Favorito>
  {

    Favorito FindByBookId(string id);

  }
}