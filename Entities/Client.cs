using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;

namespace API.Entities
{
  public class Client
  {
    protected Client() { }

    public Client(string name, string description, string phone, string email, decimal totalPayment)
    {
      Name = name;
      Description = description;
      Phone = phone;
      Email = email;
      TotalPayment = totalPayment;
      Active = ActiveEnum.Ativo;
      Projects = new List<Project>();
    }

    [Key]
    public Guid Id { get; private set; }

    [StringLength(200)]
    public string Name { get; private set; }

    [StringLength(500)]
    public string Description { get; private set; }

    [StringLength(16)]
    public string Phone { get; private set; }

    [StringLength(150)]
    public string Email { get; private set; }

    [Column(TypeName = ("decimal(9,2)"))]
    public decimal TotalPayment { get; private set; }
    public ICollection<Project> Projects { get; private set; }
    public ActiveEnum Active { get; private set; }

    public void ToInactive()
    {
      if (Active != ActiveEnum.Ativo)
      {
        throw new Exception("Estado inválido.");
      }

      Active = ActiveEnum.Inativo;
    }

    public void InputUpdate(string phone, string email, decimal totalPayment)
    {
      Phone = phone;
      Email = email;
      TotalPayment = totalPayment;
    }
  }
}
