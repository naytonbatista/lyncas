using System.Collections.Generic;

namespace lyncas.ViewModels.Converters
{
  public interface IParser<O, D>
  {
    D Parse(O origin);

    List<D> Parse(List<O> origin);
  }
}