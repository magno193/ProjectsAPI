using System;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Enums;
using API.InputModels;
using API.Persistence;
using API.ViewModels;
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
    public async Task<IActionResult> GetAll()
    {
      var clients = await _apiContext.Clients.ToListAsync();
      var clientsViewModel = clients
        .Select(c => new ClientViewModel(c.Id, c.Name, c.Phone, c.Active))
        .ToList();

      return Ok(clientsViewModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
      var client = await _apiContext.Clients.SingleOrDefaultAsync(p => p.Id == id);
      if (client == null) throw new Exception("Cliente não encontrado");
      return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClientInputModel request)
    {
      var client = new Client(
        name: request.Name,
        description: request.Description,
        phone: request.Phone,
        email: request.Email,
        totalPayment: request.TotalPayment
      );
      await _apiContext.Clients.AddAsync(client);
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return CreatedAtAction(nameof(GetById), client, new { id = client.Id });
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] ClientUpdateInputModel request)
    {
      var client = await _apiContext.Clients.FindAsync(id);
      if (client == null) throw new Exception("Cliente não encontrado");

      client.InputUpdate(request.Email, request.Phone, request.TotalPayment);

      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return NoContent();
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDelete(Guid id)
    {
      var client = await _apiContext.Clients.SingleOrDefaultAsync(c => c.Id == id);
      if (client == null) throw new Exception("Cliente não encontrado");

      client.ToInactive();
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return NoContent();
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }
  }
}
