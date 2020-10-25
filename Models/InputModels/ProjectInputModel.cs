using System;
using API.Enums;

namespace API.Models.InputModels
{
  public class ProjectInputModel
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Budget { get; set; }
    public Guid IdClient { get; set; }
  }
}
