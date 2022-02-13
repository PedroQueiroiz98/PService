using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PService.API;
using PService.API.Controllers;
using PsService.Domain;
using Xunit;

namespace PService.UnitTest;

public class OrderServiceControllerTest
{

    private Mock<ILogger<OrderServiceController>> _loggerMock;
    private Mock<IOrderServiceRepository> _repositoryMock;
    public OrderServiceControllerTest(){

        _loggerMock = new Mock<ILogger<OrderServiceController>>();
        _repositoryMock =  new Mock<IOrderServiceRepository>();
    }
    
    [Fact]
    public async Task Create_order_with_response_sucess()
    {

       
        _repositoryMock.Setup(repo=>repo.UnitOfWork.SaveEntitiesAsync(default(CancellationToken)))
                       .Returns(Task.FromResult<bool>(true));
                    
        _repositoryMock.Setup(repo=>repo.GetOrderAsync(It.IsAny<int>()))
                       .Returns(Task.FromResult<OrderService>(new OrderService(1,"service fake","description fake")));
                                    
        var controller = new OrderServiceController(_loggerMock.Object,_repositoryMock.Object);

        var request = new OrderServiceRequest();

        
        //Act
        var response =  await controller.CreateOrder(request);
        
        //asset
        Assert.Equal((response as CreatedAtActionResult).StatusCode,(int)System.Net.HttpStatusCode.Created);


    }
}