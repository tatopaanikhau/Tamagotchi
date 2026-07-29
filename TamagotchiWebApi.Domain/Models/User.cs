namespace TamagotchiWebApi.Domain.Models;

public class User : BaseModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public ICollection<Pet> Pets { get; set; } = new List<Pet>();
}