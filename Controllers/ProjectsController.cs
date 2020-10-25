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
    public async Task<IActionResult> GetById(Guid id)
    {
      var project = await _apiContext.Projects.SingleOrDefaultAsync(p => p.Id == id);
      if (project == null) throw new Exception("Projeto não encontrado");
      return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Project request)
    {
      _apiContext.Projects.Add(request);
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return CreatedAtAction(nameof(GetById), request, new { id = request.Id });
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Project request)
    {
      var project = await _apiContext.Projects.FindAsync(id);
      if (project == null) throw new Exception("Projeto não encontrado");

      _apiContext.Entry(request).State = EntityState.Modified;
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return NoContent();
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDelete(Guid id)
    {
      var project = await _apiContext.Projects.SingleOrDefaultAsync(p => p.Id == id);
      if (project == null) throw new Exception("Projeto não encontrado");

      project.ToInactive();
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return NoContent();
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }
  }
}
