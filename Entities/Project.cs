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

    public Project(
      string name,
      decimal budget,
      decimal hoursWorked,
      DateTime startDate,
      DateTime endDate,
      DateTime expectedDate
    )
    {
      Name = name;
      Budget = budget;
      Payments = new List<Payment>();
      HoursWorked = hoursWorked;
      StartDate = startDate;
      EndDate = endDate;
      ExpectedDate = expectedDate;
      Active = ActiveEnum.Ativo;
      Status = StatusEnum.EmEspera;
    }

    [Key]
    public Guid Id { get; private set; }

    [StringLength(200)]
    public string Name { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }

    [Column(TypeName = ("decimal(9,2)"))]
    public decimal Budget { get; set; }
    public List<Payment> Payments { get; set; }

    [Column("decimal(5,2)")]
    public decimal HoursWorked { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime ExpectedDate { get; set; }
    public StatusEnum Status { get; set; }
    public ActiveEnum Active { get; set; }

    public Guid IdClient { get; set; }
    public Client Client { get; set; }
  }
}
