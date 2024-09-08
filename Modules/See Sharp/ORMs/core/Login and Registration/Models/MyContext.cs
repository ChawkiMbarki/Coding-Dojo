#pragma warning disable CS8618
using Login_and_Registration.Models;
using Microsoft.EntityFrameworkCore;

namespace Login_and_Registration.Models;

public class MyContext : DbContext
{
  public MyContext(DbContextOptions<MyContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }
}

