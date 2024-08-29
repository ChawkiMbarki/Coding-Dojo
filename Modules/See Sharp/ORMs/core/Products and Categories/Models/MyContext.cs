#pragma warning disable CS8618
using Products_and_Categories.Models;
using Microsoft.EntityFrameworkCore;

namespace Products_and_Categories.Models;

public class MyContext : DbContext
{
  public MyContext(DbContextOptions<MyContext> options) : base(options) { }

  public DbSet<Category> Categories { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Association> Associations { get; set; }
}
