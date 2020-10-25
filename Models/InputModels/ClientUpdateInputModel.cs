using API.Enums;

namespace API.Models.InputModels
{
  public class ClientUpdateInputModel
  {
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal TotalPayment { get; set; }
  }
}
