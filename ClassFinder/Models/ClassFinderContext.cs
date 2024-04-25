using Microsoft.EntityFrameworkCore;

namespace ClassFinder.Models;
public class ClassFinderContext : DbContext
{
  public DbSet<Business> Businesses { get; set; }
  public DbSet<Class> Classes { get;}
  public DbSet<Catagory> Catagories { get; set; }
  public ClassFinderContext(DbContextOptions<ClassFinderContext> options) : base(options) { }
}