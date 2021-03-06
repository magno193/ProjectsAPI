using System;
using API.Enums;

namespace API.Models.InputModels
{
  public class ProjectUpdateInputModel
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int HoursWorked { get; set; }
    public StatusEnum Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime ExpectedDate { get; set; }
  }
}
