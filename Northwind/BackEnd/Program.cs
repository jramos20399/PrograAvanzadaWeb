using Entities.Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


#region ConnectionString

builder.Services.AddDbContext<NorthWindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
string connString = builder.Configuration.GetConnectionString("DefaultConnection");
Util.ConnectionString = connString;


#endregion

#region Serilog
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Host.UseSerilog((ctx, lc)=> lc
    .WriteTo.File("logs/LogsBackEnd.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Debug()
    );


#endregion



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
