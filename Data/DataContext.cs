using Microsoft.EntityFrameworkCore;
using movieflix_api.Models;

namespace movieflix_api.Data
{
  public class DataContext : DbContext
  {
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
  }
}