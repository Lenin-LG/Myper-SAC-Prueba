using Microsoft.EntityFrameworkCore;
using Trabajadores.Application.Services;
using Trabajadores.Domain.Enums;
using Trabajadores.Domain.Ports;
using Trabajadores.Domain.Ports.@out;
using Trabajadores.Infrastructure.Persistence;
using Trabajadores.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WorkerDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IFileStorage, FakeCloudStorage>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<WorkerService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SupportNonNullableReferenceTypes();
});

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WorkerDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    const int maxRetries = 10;
    var delay = TimeSpan.FromSeconds(10);

    for (int attempt = 1; attempt <= maxRetries; attempt++)
    {
        try
        {
            logger.LogInformation("Intentando aplicar migrations... intento {Attempt}", attempt);
            db.Database.Migrate();
            logger.LogInformation("Migraciones aplicadas correctamente");

            // SEED
            if (!db.Workers.Any())
            {
                logger.LogInformation("Insertando datos iniciales...");

                db.Workers.AddRange(
                    new Worker(
                        "Juan", "Perez",
                        DocumentType.DNI, "12345678",
                        Gender.Masculino,
                        new DateTime(1995, 5, 10),
                        "Lima",
                        null
                    ),
                    new Worker(
                        "Ana", "Torres",
                        DocumentType.Pasaporte, "AA999999",
                        Gender.Femenino,
                        new DateTime(1998, 2, 20),
                        "Cusco",
                        null
                    )
                );

                db.SaveChanges();
                logger.LogInformation("Datos iniciales insertados");
            }

            break;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "No se pudo conectar a la BD en el intento {Attempt}", attempt);

            if (attempt == maxRetries)
                throw;

            Thread.Sleep(delay);
        }
    }
}



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
