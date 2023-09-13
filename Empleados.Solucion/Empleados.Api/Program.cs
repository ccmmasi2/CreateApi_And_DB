using Empleados.Infraestructura.Data;
using Empleados.Infraestructura.Inicializador;
using Empleados.Infraestructura.Repositorio;
using Empleados.Infraestructura.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                                            options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDbInicializador, DbInicializador>();
builder.Services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var inicializador = services.GetRequiredService<IDbInicializador>();
        inicializador.Inicializar();
    }
    catch (Exception ex) 
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Un error ocurri� al ejecutar la migraci�n");
    }
}

    app.MapControllers();

app.Run();
