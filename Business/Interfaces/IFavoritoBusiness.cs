using System.Collections.Generic;
using System.Threading.Tasks;
using lyncas.ViewModels;

namespace lyncas.Business.Interfaces
{
  public interface IFavoritoBusiness
  {
    FavoritoVM Add(FavoritoVM favorito);

    Task<string> FindAll();

    void Delete(string id);

  }
}