#pragma warning disable CS8618
using Belt_Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Belt_Exam.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Recipy> Recipies { get; set; }
    public DbSet<Rating> Ratings { get; set; }
}