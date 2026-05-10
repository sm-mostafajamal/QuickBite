using Microsoft.EntityFrameworkCore;
using QuickBite.Domain.Entities;

namespace QuickBite.Infrastructure.Persistence;

public class QuickBiteDbContext(DbContextOptions<QuickBiteDbContext> options) 
    : DbContext(options)
{
    public DbSet<User> Users {set; get; } = null!; 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuickBiteDbContext).Assembly);
    }
}