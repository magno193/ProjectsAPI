using System.Collections.Generic;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/projects")]
  public class ProjectsController : ControllerBase
  {
    [HttpGet]
    public ActionResult List()
    {
      return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      return Ok();
    }

    [HttpPost]
    public IActionResult Post()
    {
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id)
    {
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return Ok();
    }
  }
}
