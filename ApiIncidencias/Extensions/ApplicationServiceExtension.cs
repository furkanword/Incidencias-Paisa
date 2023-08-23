using System.Net;
using Aplicacion.UnitOfWork;
using AspNetCoreRateLimit;
using Dominio.Interfaces;
using iText.Kernel.Crypto.Securityhandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

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

    public static void ConfigureRatelimiting(this IServiceCollection services){
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(Options => {
            Options.EnableEndpointRateLimiting = true;
            Options.StackBlockedRequests = false;
            Options.HttpStatusCode = 429;
            Options.RealIpHeader = "x-Real-Ip";
            Options.GeneralRules = new List<RateLimitRule>{
                new RateLimitRule
                {
                    Endpoint = "*",
                    Period = "10s",
                    Limit = 2
                }
            };
        });
    }
    public static void ConfigureApiVersioning(this IServiceCollection services){
        services.AddApiVersioning(options => {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("ver"),
                new HeaderApiVersionReader("x-Version")
            );
        });
    }
   


    
}
