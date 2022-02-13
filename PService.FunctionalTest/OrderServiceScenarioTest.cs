namespace PService.FunctionalTest;

using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PService.API;
using Xunit;
public class OrderServiceScenarioTest : TestServerHostBuilder
{

    [Fact]
    public async Task Create_order_service_response_created_ok(){

         using (var server = BuildServer())
        {
                       
            var content = new StringContent(BuilderOrderService(), UTF8Encoding.UTF8, "application/json");

            var response = await server.CreateClient().PostAsync("api/v1/OrderService",content);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
    public string BuilderOrderService(){

         var order = new OrderServiceRequest(){
                CustomerId = 1,
                ServiceName = "Service Fake",
                ServiceDescription = "Service description Fake"
        };

         return JsonSerializer.Serialize(order);
    }
}
