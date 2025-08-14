










// ------------------- Program.cs (C#) -------------------
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers();
builder.Services.AddScoped<IMiServicio, MiServicio>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Configuración de logging
builder.Logging.AddConsole();

var app = builder.Build();

// Middleware
app.UseRouting();
app.UseCors("AllowAll");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/ping", async context =>
    {
        await context.Response.WriteAsync($"Pong at {DateTime.Now}");
    });
});

app.Run();

public interface IMiServicio
{
    Task<string> ObtenerDatosAsync();
}

public class MiServicio : IMiServicio
{
    public async Task<string> ObtenerDatosAsync()
    {
        await Task.Delay(100);
        return "Datos del servicio";
    }
}