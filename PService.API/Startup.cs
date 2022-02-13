

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PService.Infrastructure;
using PService.Infrastructure.Repository;
using PsService.Domain;

namespace PService.API;

public class Startup 
{   
    private readonly IConfiguration Configuration;

    public Startup(IConfiguration configuration){

        Configuration = configuration;
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseRouting();
        app.UseEndpoints(x=>{
            x.MapControllers();
        });
    }

    public void ConfigureServices(IServiceCollection services)
    {        
        
        var connetionString = Environment.GetEnvironmentVariable("ORDER_CONTEXT",EnvironmentVariableTarget.Process);
        services.AddDbContext<OrderContext>(x=>{
            x.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString),
            sqlOptions=>{
                 sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                 sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            });
        });
                                                            
                                                        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddRepository();
    }
}

public static class ServiceInjectionExtension{

    public static IServiceCollection AddRepository(this IServiceCollection services){

        services.AddScoped<IOrderServiceRepository,OrderServiceRepository>();
        return services;
    }
}