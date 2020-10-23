using System;
using System.Threading.Tasks;
using API.Entities;
using API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/projects")]
  public class ProjectsController : ControllerBase
  {
    private readonly ApiContext _apiContext;
    public ProjectsController(ApiContext apiContext)
    {
      _apiContext = apiContext;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
      var projects = await _apiContext.Projects.ToListAsync();

      return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
      var project = await _apiContext.Projects.SingleOrDefaultAsync(p => p.Id == id);
      return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Project request)
    {
      _apiContext.Projects.Add(request);
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return CreatedAtAction(nameof(List), request, new { id = request.Id });
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Project request)
    {
      var findProject = await _apiContext.Projects.FindAsync(id);
      if (findProject == null) throw new Exception("Projeto não encontrado");

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
      return Ok();
    }
  }
}
