using Microsoft.EntityFrameworkCore;

namespace ClassFinder.Models;
public class ClassFinderContext : DbContext
{
  public DbSet<Company> Companies { get; set; }
  public DbSet<Course> Courses { get; set; }
  public DbSet<Category> Categories { get; set; }
  public ClassFinderContext(DbContextOptions<ClassFinderContext> options) : base(options) { }
}