using System;
using System.Threading.Tasks;
using API.Entities;
using API.Models.InputModels;
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
    public async Task<IActionResult> Post([FromBody] ProjectInputModel request)
    {
      var project = new Project(
        name: request.Name,
        description: request.Description,
        budget: request.Budget,
        idClient: request.IdClient
      );
      _apiContext.Projects.Add(project);
      var success = await _apiContext.SaveChangesAsync() > 0;

      if (success) return CreatedAtAction(nameof(GetById), project, new { id = project.Id });
      throw new Exception("Ocorreu um problema ao salvar os dados");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] ProjectUpdateInputModel request)
    {
      var project = await _apiContext.Projects.FindAsync(id);
      if (project == null) throw new Exception("Projeto não encontrado");

      project.InputUpdate(
        name: request.Name,
        description: request.Description,
        hoursWorked: request.HoursWorked,
        status: request.Status,
        startDate: request.StartDate,
        endDate: request.EndDate,
        expectedDate: request.ExpectedDate
      );
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
