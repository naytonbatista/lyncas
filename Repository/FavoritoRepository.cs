using System.Linq;
using lyncas.Model;
using lyncas.Model.Context;
using lyncas.Repository.Generic;
using lyncas.Repository.Interfaces;

namespace lyncas.Repository
{
  public class FavoritoRepository : GenericRepository<Favorito>, IFavoritoRepository
  {
    public FavoritoRepository(Context context) : base(context)
    {

    }

    public Favorito FindByBookId(string id)
    {
      return _context.Favoritos.SingleOrDefault(fav => fav.BookId == id);
    }
  }
}