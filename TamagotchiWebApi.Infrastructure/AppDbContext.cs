using Microsoft.EntityFrameworkCore;
using TamagotchiWebApi.Domain.Models;

namespace TamagotchiWebApi.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}
    public DbSet<Pet> Pets => Set<Pet>();
}