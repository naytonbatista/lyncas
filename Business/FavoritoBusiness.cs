using System.Collections.Generic;
using System.Threading.Tasks;
using lyncas.Business.Interfaces;
using lyncas.Model;
using lyncas.Repository.Interfaces;
using lyncas.Services.Interfaces;
using lyncas.ViewModels;
using lyncas.ViewModels.Converters;

namespace lyncas.Business
{

  public class FavoritoBusiness : IFavoritoBusiness
  {

    private readonly IFavoritoRepository _repository;

    private readonly FavoritoConverter _converter;

    private readonly IBookService _bookService;

    public FavoritoBusiness(IFavoritoRepository repository, IBookService bookService)
    {
      _repository = repository;
      _bookService = bookService;
      _converter = new FavoritoConverter();
    }
    public FavoritoVM Add(FavoritoVM favorito)
    {

      var model = _converter.Parse(favorito);
      var result = _repository.Create(model);

      return _converter.Parse(result);
    }

    public void Delete(string id)
    {

      var fav = _repository.FindByBookId(id);

      _repository.Delete(fav.Id);
    }

    public async Task<string> FindAll()
    {
      var favs = _converter.Parse(_repository.FindAll());
      string items = "";

      foreach (var fav in favs)
      {
        items += await _bookService.FindById(fav.BookId);
        items += ",";
      }
      var total = favs.Count <= 0 ? "[]" : $"[{items.Remove(items.Length - 1)}]";
      return "{\"count\": " + favs.Count + ", \"items\": " + total + "}";
    }
  }
}