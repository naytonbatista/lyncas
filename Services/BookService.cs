using System.Net.Http;
using System.Threading.Tasks;

using lyncas.Services.Interfaces;

namespace lyncas.Services
{


  public class BookService : IBookService
  {
    private readonly HttpClient _client;

    public BookService(HttpClient client)
    {
      _client = client;
    }

    public async Task<string> FindById(string volumeId)
    {
      var response = await _client.GetStringAsync($"/books/v1/volumes/{volumeId}");
      return response;
    }

    public async Task<string> Get(string query, int pageIndex, int pageSize)
    {
      var startIndex = pageIndex * pageSize;

      var response = await _client.GetStringAsync($"/books/v1/volumes?q={query}&startIndex={startIndex}&maxResults={pageSize}");

      return response;
    }
  }
}