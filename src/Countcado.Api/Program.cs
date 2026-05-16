using Countcado.Api.Middleware;
using Countcado.Application.Extensions;
using Countcado.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ── Controladores ──────────────────────────────────────────────────────────────
builder.Services.AddControllers();

// ── Swagger / OpenAPI ──────────────────────────────────────────────────────────
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Countcado API",
        Version = "v1",
        Description = "Backend API del proyecto Countcado."
    });
});

// ── Capas de la aplicación ─────────────────────────────────────────────────────
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// ── CORS ───────────────────────────────────────────────────────────────────────
var frontendUrl = builder.Configuration["ApiSettings:FrontendUrl"] ?? "http://localhost:4200";

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
        policy.WithOrigins(frontendUrl)
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// ═══════════════════════════════════════════════════════════════════════════════

var app = builder.Build();

// ── Middleware de excepciones ──────────────────────────────────────────────────
app.UseMiddleware<ExceptionHandlingMiddleware>();

// ── Swagger (solo en desarrollo) ───────────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Countcado API v1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz: http://localhost:5000/
    });
}

app.UseHttpsRedirection();
app.UseCors("FrontendPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
