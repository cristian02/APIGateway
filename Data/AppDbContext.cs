using Microsoft.EntityFrameworkCore;
using GlobalErrorApi.Models; 
namespace GlobalErrorApi.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {   
    }
    public DbSet<Driver> Drivers{get;set;}

}