using System;
using API.Enums;

namespace API.Entities
{
  public class Payment
  {
    protected Payment() { }
    public Payment(Guid id, decimal value, MethodEnum method)
    {
      Id = id;
      Value = value;
      Method = method;
    }
    public Guid Id { get; private set; }
    public decimal Value { get; private set; }
    public MethodEnum Method { get; private set; }
    public Boolean? Portion { get; private set; }
    public int? Quantity { get; private set; }
    public DateTime PaymentDate { get; private set; }

    public Guid IdProject { get; private set; }
    public Project Project { get; private set; }
  }
}
