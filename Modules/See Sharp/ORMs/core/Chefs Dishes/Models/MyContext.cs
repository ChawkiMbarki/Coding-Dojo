#pragma warning disable CS8618
using Chefs_Dishes.Models;
using Microsoft.EntityFrameworkCore;

namespace Chefs_Dishes.Models;

public class MyContext : DbContext
{
  public MyContext(DbContextOptions<MyContext> options) : base(options) { }

  public DbSet<Chef> Chefs { get; set; }
  public DbSet<Dish> Dishes { get; set; }
}