using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using GlobalErrorApi.Models; 
namespace GlobalErrorApi.Data;
public class AppDbContext : DbContext
{
    public DbSet<Driver> Drivers{get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>()
            .HasIndex(p => p.Name)
            .IsUnique(true);
    }

    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {   
    }

    
}