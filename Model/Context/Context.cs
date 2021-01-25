using Microsoft.EntityFrameworkCore;

namespace lyncas.Model.Context
{
  public class Context : DbContext
  {
    public Context()
    {

    }

    public Context(DbContextOptions<Context> options) : base(options)
    {

    }
    public DbSet<Favorito> Favoritos { get; set; }
  }
}