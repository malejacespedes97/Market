using Market.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Market.WEB.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//como hacer una inyección de dependencia? con un buider services
//Inyeccion de dependencia a SQL Server
//x => x. significa lambda
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=DefaultConnection")); //cadena de conexión

//HttpClient para consumir el API desde la web

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:8000") });
//cambia desde la palabra services, cuando ejecute la web, recibira los parametros

//builder.Services.AddScoped<IRepository, Repository>();

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

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.Run();
