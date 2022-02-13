using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PService.Infrastructure;

namespace PService.API;

public class StartupTest : Startup
{
    public StartupTest(IConfiguration configuration) : base(configuration)
    {
    }

    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
    }
    protected override void ConfigurationDataBase(IServiceCollection services)
    {
        var connetionString = Environment.GetEnvironmentVariable("ORDER_CONTEXT_TEST",EnvironmentVariableTarget.Machine);
         services.AddDbContext<OrderContext>(x=>{
            x.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString),
            sqlOptions=>{
                 sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                 sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            });
        });
    }
}
