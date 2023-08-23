using System.Reflection;
using ApiIncidencias.Extensions;
using AspNetCoreRateLimit;
using iText.Kernel.XMP.Options;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(Options =>{
    Options.RespectBrowserAcceptHeader = true;
    Options.ReturnHttpNotAcceptable = true;
}).AddXmlSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureRatelimiting();
builder.Services.ConfigureApiVersioning();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureCors();
builder.Services.AddAplicacionServieces();
builder.Services.AddDbContext<ApiIncidenciasContext>(Options =>
{
    string ? connectionString  = builder.Configuration.GetConnectionString("ConexMysql");
    Options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//Contenedor de 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsPolicy");

app.UseHttpsRedirection();

app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();
