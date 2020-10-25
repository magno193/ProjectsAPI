using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;

namespace API.Entities
{
  public class Project
  {
    protected Project() { }
    public Project(string name, string description, decimal budget, Guid idClient)
    {
      Name = name;
      Description = description;
      Budget = budget;
      HoursWorked = 0;
      Status = StatusEnum.Pendente;
      Active = ActiveEnum.Ativo;
      IdClient = idClient;
    }

    [Key]
    public Guid Id { get; private set; }

    [StringLength(200)]
    public string Name { get; private set; }

    [StringLength(1000)]
    public string Description { get; private set; }

    [Column(TypeName = ("decimal(9,2)"))]
    public decimal Budget { get; private set; }
    public List<Payment> Payments { get; private set; }

    [Column(TypeName = "tinyint")]
    public int HoursWorked { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime ExpectedDate { get; private set; }
    public StatusEnum Status { get; private set; }
    public ActiveEnum Active { get; private set; }

    public Guid IdClient { get; set; }
    public Client Client { get; set; }

    public void ToInactive()
    {
      if (Active != ActiveEnum.Ativo)
      {
        throw new Exception("Estado inválido.");
      }

      Active = ActiveEnum.Inativo;
    }

    public void InputUpdate(
      string name,
      string description,
      int hoursWorked,
      StatusEnum status,
      DateTime startDate,
      DateTime endDate,
      DateTime expectedDate
    )
    {
      Name = name ?? Name;
      Description = description ?? Description;
      HoursWorked = hoursWorked | HoursWorked;
      Status = status | Status;
      StartDate = startDate;
      EndDate = endDate;
      ExpectedDate = expectedDate;
    }
  }
}
