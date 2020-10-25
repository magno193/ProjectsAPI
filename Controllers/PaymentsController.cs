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
    public async Task<IActionResult> GetAll()
    {
      var payments = await _apiContext.Payments.ToListAsync();

      return Ok(payments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
      var payment = await _apiContext.Payments.SingleOrDefaultAsync(p => p.Id == id);
      if (payment == null) throw new Exception("Pagamento não encontrado");
      return Ok(payment);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Payment request)
    {
      _apiContext.Payments.Add(request);
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return CreatedAtAction(nameof(GetById), request, new { id = request.Id });
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Payment request)
    {
      var payment = await _apiContext.Payments.FindAsync(id);
      if (payment == null) throw new Exception("Pagamento não encontrado");

      _apiContext.Entry(request).State = EntityState.Modified;
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return NoContent();
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDelete(Guid id)
    {
      var payment = await _apiContext.Payments.SingleOrDefaultAsync(p => p.Id == id);
      if (payment == null) throw new Exception("Pagamento não encontrado");

      payment.ToInactive();
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return NoContent();
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }
  }
}
