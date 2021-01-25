using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lyncas.Business.Interfaces;
using lyncas.Services.Interfaces;
using lyncas.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lyncas.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BookController : ControllerBase
  {

    private IBookService _service;
    private IFavoritoBusiness _favBusiness;
    public BookController(IBookService service, IFavoritoBusiness favBusiness)
    {
      _favBusiness = favBusiness;
      _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string p = "", int page = 0, int pageSize = 10)
    {
      try
      {
        var response = await _service.Get(p, page, pageSize);

        return Ok(response);
      }
      catch (Exception exc)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new
        {
          Message = exc.Message,
          InnerException = exc.InnerException
        });
      }
    }

    [HttpPost]
    [Route("{id}/favorite")]
    public IActionResult Post(string id)
    {
      try
      {
        var response = _favBusiness.Add(new FavoritoVM { BookId = id });

        return Ok(response);
      }
      catch (Exception exc)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new
        {
          Message = exc.Message,
          InnerException = exc.InnerException
        });
      }
    }

    [HttpGet]
    [Route("favorites")]
    public async Task<IActionResult> Favoritos()
    {
      try
      {
        var response = await _favBusiness.FindAll();

        return Ok(response);
      }
      catch (Exception exc)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new
        {
          Message = exc.Message,
          InnerException = exc.InnerException
        });
      }

    }

    [HttpDelete]
    [Route("{id}/favorite")]
    public IActionResult Delete(string id)
    {
      try
      {
        _favBusiness.Delete(id);

        return NoContent();
      }
      catch (Exception exc)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new
        {
          Message = exc.Message,
          InnerException = exc.InnerException
        });
      }

    }



  }
}
