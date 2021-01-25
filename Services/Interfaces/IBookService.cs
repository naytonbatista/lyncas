using System.Threading.Tasks;

namespace lyncas.Services.Interfaces
{
  public interface IBookService
  {
    Task<string> Get(string query, int pageIndex, int pageSize);

    Task<string> FindById(string volumeId);

  }
}