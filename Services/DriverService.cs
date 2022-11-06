using GlobalErrorApi.Data;
using GlobalErrorApi.Models;
using Microsoft.EntityFrameworkCore; 

namespace GlobalErrorApi.Services;
public class DriverService : IDriverService
{
    public readonly AppDbContext _dbContext;
    public DriverService(AppDbContext dbContext)
    {
        _dbContext = dbContext; 
    }

    public async Task<Driver> AddDriver(Driver driver)
    {
        var result = await _dbContext.Drivers.AddAsync(driver);
        await _dbContext.SaveChangesAsync();
        return result.Entity; 
    }

    public async Task<bool> DeleteDriver(int id)
    {
        var driver = await GetDriverById(id);
        _dbContext.Remove(driver); 
        await _dbContext.SaveChangesAsync();
        return driver != null ? true : false; 

    }

    public async Task<Driver?> GetDriverById(int id)
    {
        return await _dbContext.Drivers.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<IEnumerable<Driver>> GetDrivers()
    {
        return await _dbContext.Drivers.ToListAsync();
    }

    public async Task<Driver> UpdateDriver(Driver driver)
    {
        var result = _dbContext.Drivers.Update(driver);
        await _dbContext.SaveChangesAsync();
        return result.Entity; 
    }
}