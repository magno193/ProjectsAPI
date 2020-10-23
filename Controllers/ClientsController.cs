using System;
using System.Threading.Tasks;
using API.Entities;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/clients")]
  public class ClientsController : ControllerBase
  {
    private readonly ApiContext _apiContext;
    public ClientsController(ApiContext apiContext)
    {
      _apiContext = apiContext;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
      var clients = await _apiContext.Clients.ToListAsync();

      return Ok(clients);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
      var client = await _apiContext.Clients.SingleOrDefaultAsync(p => p.Id == id);
      return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Client request)
    {
      _apiContext.Clients.Add(request);
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return CreatedAtAction(nameof(List), request, new { id = request.Id });
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }

  }
}
