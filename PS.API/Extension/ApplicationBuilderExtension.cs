using Microsoft.EntityFrameworkCore;

namespace PS.API.Extension
{
    public  static class WebApplicationExtension
    {
        
        public static IApplicationBuilder MigrationDbContext<Context>(this IApplicationBuilder app) where Context : DbContext{

            using(var serviceScoped = app.ApplicationServices.CreateScope()){
                var context = serviceScoped.ServiceProvider.GetService<Context>();
                context?.Database.Migrate();
            }
            
            return app;
        }
    }
}