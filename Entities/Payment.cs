using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;

namespace API.Entities
{
  public class Payment
  {
    protected Payment() { }
    public Payment(
      decimal value,
      Boolean portion,
      int quantity,
      DateTime paymentDate
    )
    {
      Value = value;
      Portion = portion;
      Quantity = quantity;
      PaymentDate = paymentDate;
    }

    [Key]
    public Guid Id { get; private set; }

    [Column(TypeName = "decimal(9, 2)")]
    public decimal Value { get; private set; }
    public MethodEnum Method { get; private set; }
    public Boolean? Portion { get; private set; }

    [Column(TypeName = "tinyint")]
    public int? Quantity { get; private set; }
    public DateTime PaymentDate { get; private set; }

    public Guid IdProject { get; private set; }
    public Project Project { get; private set; }
  }
}
