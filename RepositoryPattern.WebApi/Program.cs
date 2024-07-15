using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryPattern.DataAccess.EfCore;
using RepositoryPattern.DataAccess.EfCore.Repositories;
using RepositoryPattern.DataAccess.EfCore.UnitOfWork;
using RepositoryPattern.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// db context
builder.Services.AddDbContext<EfRelationshipsContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(EfRelationshipsContext).Assembly.FullName)));
// db context

#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericRepositoryV2<>), typeof(GenericRepositoryV2<>));
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
#endregion

#region cycle dependency resolver of json
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
#endregion

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
