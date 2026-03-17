using ApiJugadoresDb.Features.Jugadores.AppServices;
using ApiJugadoresDb.Features.Jugadores.DomainServices;
using ApiJugadoresDb.Features.Jugadores.Interfaces;
using ApiJugadoresDb.Infrastructure.Databases;
using ApiJugadoresDb.Infrastructure.Interfaces;
using ApiJugadoresDb.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//BASE DE DATOS
// Base de datos
builder.Services.AddDbContext<JugadoresDbContext>(
    options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DbPeliculasConnectionString"
        )
    )
 );

//SERVICIOS
builder.Services.AddScoped<
    IJugadoresRepository,
    JugadoresRepository>();
builder.Services.AddScoped<
    IPosicionesRepository,
    PosicionesRepository>();
builder.Services.AddScoped<
    IJugadoresAppService,
    JugadoresAppService>();
builder.Services.AddScoped<
    IPosicionesAppService,
    PosicionesAppService>();
builder.Services.AddScoped<JugadoresDomainService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
