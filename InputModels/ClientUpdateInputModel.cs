namespace API.InputModels
{
  public class ClientUpdateInputModel
  {
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public decimal TotalPayment { get; private set; }
  }
}
