

using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PService.Infrastructure;
using PService.Infrastructure.Identity;
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
        app.RunMigrations();
    }

    public virtual void ConfigureServices(IServiceCollection services)
    {        
        
                                                        
        ConfigurationDataBase(services);
        ConfigurationAuthentication(services);                              
        services.AddControllers(x=>{
            x.SuppressAsyncSuffixInActionNames = false;
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddRepository();
    }
    protected virtual void ConfigurationDataBase(IServiceCollection services){

         var connetionString = Environment.GetEnvironmentVariable("ORDER_CONTEXT",EnvironmentVariableTarget.Process);
         if(connetionString is null) connetionString = Environment.GetEnvironmentVariable("ORDER_CONTEXT",EnvironmentVariableTarget.Machine);
         services.AddDbContext<OrderContext>(x=>{
            x.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString),
            sqlOptions=>{
                 sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                 sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            });
        });
    }
    private void ConfigurationAuthentication(IServiceCollection services){
        services.AddScoped<ILoginService,LoginService>();
    }
}

public static class ServiceInjectionExtension{

    public static IServiceCollection AddRepository(this IServiceCollection services){

        services.AddScoped<IOrderServiceRepository,OrderServiceRepository>();
        return services;
    }
     public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "Please refer to the errors property for additional details."
                };

                return new BadRequestObjectResult(problemDetails)
                {
                    ContentTypes = { "application/problem+json", "application/problem+xml" }
                };
            };
        });

        return services;
    }
}
public static class AppBuilderExtension{

    public static IApplicationBuilder RunMigrations(this IApplicationBuilder app){

         using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<OrderContext>())
            {
                context.Database.Migrate();
            }
        }
        return app;
    }
}