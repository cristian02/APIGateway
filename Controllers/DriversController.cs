using System.Diagnostics;
using System.Net;
using GlobalErrorApi.Models;
using GlobalErrorApi.Services;
using Microsoft.AspNetCore.Mvc;
using GlobalErrorApi.Exceptions; 

namespace GlobalErrorApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly ILogger<DriversController> _logger;
    private readonly IDriverService _driverService; 

    public DriversController(ILogger<DriversController> logger, IDriverService driverService)
    {
        _logger = logger;
        _driverService = driverService; 
    }

    [HttpGet("DriverList")]
    public async Task<IActionResult> DriverList()
    {
        var drivers = await _driverService.GetDrivers();
        return Ok(drivers);
    }

    [HttpPost("AddDriver")]
    public async Task<IActionResult> AddDriver(Driver driver)
    {
        var result = await _driverService.AddDriver(driver); 
        return Ok(result);
    }

    [HttpGet("GetDriverById")]
    public async Task<IActionResult> DriverById(int id)
    {
        var driver = await _driverService.GetDriverById(id); 
        if (driver == null)
            throw new CustomerException()
            {
                customerMessage = "This element didn't found", 
                statusCode = HttpStatusCode.Unauthorized
            };
        return Ok(driver);
    }
}
