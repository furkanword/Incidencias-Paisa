using Aplicacion.UnitOfWork;
using Dominio.Interfaces;

namespace ApiIncidencias.Extensions;

public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(Options => {
        Options.AddPolicy("CorsPolicy" , builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    });
    public static void AddAplicacionServieces(this IServiceCollection services) {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    } 
   


    
}
