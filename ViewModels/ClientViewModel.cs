using API.Enums;

namespace API.ViewModels
{
  public class ClientViewModel
  {
    public ClientViewModel(string name, string phone, ActiveEnum active)
    {
      Name = name;
      Phone = phone;
      Active = active;
    }

    public string Name { get; private set; }
    public string Phone { get; private set; }
    public ActiveEnum Active { get; private set; }
  }
}
