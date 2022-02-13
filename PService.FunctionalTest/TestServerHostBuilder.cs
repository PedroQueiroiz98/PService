using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using PService.API;
using Microsoft.Extensions.Configuration;

namespace PService.FunctionalTest;

public class TestServerHostBuilder
{

    public TestServer BuildServer(){
        
        var path = Assembly.GetAssembly(typeof(TestServerHostBuilder))
            .Location;

        var hostBuilder = new WebHostBuilder()
            .UseContentRoot(Path.GetDirectoryName(path))
            .ConfigureAppConfiguration(cb =>
            {
                cb.AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables();
            }).UseStartup<StartupTest>();

        var testServer = new TestServer(hostBuilder);
        return testServer;
    }
}
