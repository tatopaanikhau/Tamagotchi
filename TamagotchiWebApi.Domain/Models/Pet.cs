namespace TamagotchiWebApi.Domain.Models;

public class Pet
{
    public string Name { get; set; }
    public int Age { get; private set; } = 0;
    public bool Hunger { get; set; } = false;
    public bool Thirst { get; set; } = false;
    public bool Bored { get; set; } = false;
    public int Energy { get; private set; } = 100;
    public DateTime LastInteracted  { get; set; } = DateTime.Today;
}
