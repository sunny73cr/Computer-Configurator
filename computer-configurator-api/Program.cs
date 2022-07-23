using ComputerConfigurator.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.ToString());
    c.SwaggerDoc("v0.2", new OpenApiInfo
    {
        Title = "Computer Configurator Web API - Parts",
        Version = "v0.2",
        Description = "An ASP .NET Core 6.0 Web API for managing computer parts.",
        Contact = new OpenApiContact
        {
            Name = "Dylan Avery",
            Email = "sunny73cr@protonmail.com",
            Url = new Uri("https://github.com/sunny73cr")
        },
        License = new OpenApiLicense
        {
            Name = "Licenced under MIT",
            Url = new Uri("https://mit-license.org/")
        }
    });
});

builder.Services.AddDbContext<CCContext>(options => options
    .UseNpgsql("Host=localhost;Database=cc;Username=ccNET;Password=EDhD4TWW6D9n3dV")
    .LogTo(Console.WriteLine, LogLevel.Information)
);

var app = builder.Build();

app.UseCors(policy => policy.WithOrigins("http://localhost:5000").AllowAnyHeader().AllowAnyMethod());

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v0.2/swagger.json", "ComputerConfiguratorApi v0.2"));

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
