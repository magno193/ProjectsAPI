using System;
using System.Threading.Tasks;
using API.Entities;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/payments")]
  public class PaymentsController : ControllerBase
  {
    private readonly ApiContext _apiContext;
    public PaymentsController(ApiContext apiContext)
    {
      _apiContext = apiContext;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
      var payments = await _apiContext.Payments.ToListAsync();

      return Ok(payments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
      var payment = await _apiContext.Payments.SingleOrDefaultAsync(p => p.Id == id);
      return Ok(payment);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Payment request)
    {
      _apiContext.Payments.Add(request);
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return CreatedAtAction(nameof(List), request, new { id = request.Id });
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }

  }
}
