using System;
using System.Collections.Generic;
using API.Enums;

namespace API.Entities
{
  public class Client
  {
    protected Client() { }

    public Client(
      string name,
      string phone,
      string email,
      DateTime startDate,
      DateTime endDate,
      DateTime expectedDate
    )
    {
      Name = name;
      Phone = phone;
      Email = email;
      Projects = new List<Project>();
      StartDate = startDate;
      EndDate = endDate;
      ExpectedDate = expectedDate;
      Active = ActiveEnum.Ativo;
    }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public List<Project> Projects { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime ExpectedDate { get; private set; }
    public ActiveEnum Active { get; private set; }
  }
}
