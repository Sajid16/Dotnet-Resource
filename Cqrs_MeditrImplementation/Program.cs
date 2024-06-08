using Cqrs_MeditrImplementation.Data;
using Cqrs_MeditrImplementation.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// serilog configs
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    // Filter out ASP.NET Core infrastructre logs that are Information and below
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .WriteTo.Console()
    .WriteTo.File("logs/app.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.MSSqlServer("Data Source=LAPTOP-SOC2P5QG;Initial Catalog=EfRelationships;Trusted_Connection=True;TrustServerCertificate=True",
                    new MSSqlServerSinkOptions
                    {
                        TableName = "SeriLogs",
                        SchemaName = "dbo",
                        AutoCreateSqlTable = true
                    })
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();
builder.Logging.AddSerilog();

builder.Services.AddSingleton(Log.Logger);

// serilog configs


// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
//builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddDbContext<DbContextClass>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
         ServiceLifetime.Scoped);
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
