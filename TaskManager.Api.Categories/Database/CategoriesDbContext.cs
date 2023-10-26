using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Categories.Models;

namespace TaskManager.Api.Categories.Database;

public class CategoriesDbContext : DbContext
{
    public DbSet<Entities.Category> Categories { get; set; }
    public CategoriesDbContext(DbContextOptions options) : base(options) { }
}
