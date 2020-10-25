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
    public Project(Guid id, string name, string description, decimal budget, List<Payment> payments, int hoursWorked, DateTime startDate, DateTime endDate, DateTime expectedDate, StatusEnum status, ActiveEnum active, Guid idClient, Client client)
    {
      Id = id;
      Name = name;
      Description = description;
      Budget = budget;
      Payments = payments;
      HoursWorked = hoursWorked;
      StartDate = startDate;
      EndDate = endDate;
      ExpectedDate = expectedDate;
      Status = status;
      Active = ActiveEnum.Ativo;
      IdClient = idClient;
      Client = client;
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
  }
}
