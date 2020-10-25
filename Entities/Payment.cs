using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;

namespace API.Entities
{
  public class Payment
  {
    protected Payment() { }

    public Payment(Guid id, decimal value, PaymentMethodEnum paymentMethod, bool? portion, int? quantity, DateTime paymentDate, ActiveEnum active, Guid idProject, Project project)
    {
      Id = id;
      Value = value;
      PaymentMethod = paymentMethod;
      Portion = portion;
      Quantity = quantity;
      PaymentDate = paymentDate;
      Active = active;
      IdProject = idProject;
      Project = project;
    }

    [Key]
    public Guid Id { get; private set; }

    [Column(TypeName = "decimal(9, 2)")]
    public decimal Value { get; private set; }
    public PaymentMethodEnum PaymentMethod { get; private set; }
    public Boolean? Portion { get; private set; }

    [Column(TypeName = "tinyint")]
    public int? Quantity { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public ActiveEnum Active { get; private set; }
    public Guid IdProject { get; private set; }
    public Project Project { get; private set; }

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
