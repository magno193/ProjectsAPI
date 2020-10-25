using System;
using API.Enums;

namespace API.Models.ViewModels
{
  public class ClientViewModel
  {
    public ClientViewModel(Guid id, string name, string phone, ActiveEnum active)
    {
      Id = id;
      Name = name;
      Phone = phone;
      Active = active;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public ActiveEnum Active { get; private set; }
  }
}
