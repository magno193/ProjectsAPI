using System;
using System.Collections.Generic;
using API.Enums;

namespace API.Entities
{
  public class Project
  {
    protected Project() { }

    public Project(
      string name,
      decimal budget,
      TimeSpan hoursWorked,
      DateTime startDate,
      DateTime endDate,
      DateTime expectedDate
    )
    {
      Name = name;
      Budget = budget;
      Payment = new List<Payment>();
      HoursWorked = hoursWorked;
      StartDate = startDate;
      EndDate = endDate;
      ExpectedDate = expectedDate;
      Active = ActiveEnum.Ativo;

    }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Budget { get; private set; }
    public List<Payment> Payment { get; private set; }
    public TimeSpan HoursWorked { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime ExpectedDate { get; private set; }
    public ActiveEnum Active { get; private set; }

    public Guid IdClient { get; private set; }
    public Client Client { get; private set; }
  }
}
