namespace TamagotchiWebApi.Application;

public class Pet : BaseEntity
{
    public string Name { get; set; } 
    public int Age { get; set; }
    public int Hunger { get; set; }
    
}