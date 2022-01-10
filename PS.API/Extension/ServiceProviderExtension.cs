
using Microsoft.EntityFrameworkCore;
using PS.API.Infrastructure;

namespace PS.API.Externsion{


    public static class ServiceProviderExtension{

        public static IServiceCollection ConfigureDbContextCustom(this IServiceCollection services,IConfiguration configuration){
            
            var connectionString = configuration.GetConnectionString("MySql");

            services.AddDbContext<ApplicationDbContext>(options =>

                options.UseMySql(
                    connectionString,ServerVersion.AutoDetect(connectionString),
                    provider=>provider.MigrationsAssembly("AuthMigrations")
                )
            
            );
            
            return services;
        }
    }

}