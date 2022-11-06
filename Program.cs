using GlobalErrorApi.Configurations;
using GlobalErrorApi.Data;
using GlobalErrorApi.Services;
using Microsoft.EntityFrameworkCore; 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("SampleDbConnection")));
builder.Services.AddScoped<IDriverService, DriverService>(); 
builder.Services.AddSwaggerGen(); 

//builder.Services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(opt=>opt.UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.AddGlobalErrorHandler(); 

app.Run();
