using System.Collections.Generic;
using System.Linq;
using lyncas.Model;

namespace lyncas.ViewModels.Converters
{
  public class FavoritoConverter : IParser<FavoritoVM, Favorito>, IParser<Favorito, FavoritoVM>
  {
    public Favorito Parse(FavoritoVM origin)
    {
      return new Favorito
      {
        Id = origin.Id,
        BookId = origin.BookId
      };
    }

    public List<Favorito> Parse(List<FavoritoVM> origin)
    {
      return origin.Select(x => Parse(x)).ToList();
    }

    public FavoritoVM Parse(Favorito origin)
    {
      return new FavoritoVM
      {
        Id = origin.Id,
        BookId = origin.BookId
      };
    }

    public List<FavoritoVM> Parse(List<Favorito> origin)
    {
      return origin.Select(x => Parse(x)).ToList();
    }
  }
}