namespace TamagotchiWebApi.Domain.Models;

public class Pet : BaseModel
{
    public string Name { get; set; }
    public int Age { get; private set; } = 0;
    public bool Hunger { get; set; } = false;
    public bool Thirst { get; set; } = false;
    public bool Bored { get; set; } = false;
    public int Energy { get; set; } = 100;
    public DateTime LastInteracted  { get; set; } = DateTime.UtcNow;
    // for tracking owner
    public Guid OwnerId { get; set; }
    public User Owner { get; set; } //pachi pets.owner.name garna milcha
}
