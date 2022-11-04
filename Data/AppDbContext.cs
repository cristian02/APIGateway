using Microsoft.EntityFrameworkCore;
using GlobalErrorApi.Models; 
namespace GlobalErrorApi.Data;
public class AppDbContext : DbContext
{
    public DbSet<Driver> Drivers{get;set;}
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {   
    }
}