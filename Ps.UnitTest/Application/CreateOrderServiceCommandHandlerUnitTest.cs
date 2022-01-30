using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using PS.API.Application.Commands.Order;
using Xunit;

namespace Ps.UnitTest;

public class CreateOrderServiceCommandHandlerUnitTest
{

    private readonly Mock<IMediator> _mediator;
    public  CreateOrderServiceCommandHandlerUnitTest(){

        _mediator = new Mock<IMediator>();
    }
    [Fact]
    public async Task  handler_return_true_if_create_order_sucess()
    {   

        
        var fakeOrderServiceCommand = FakeOrderServiceRequest();
        var loggerMock = new Mock<ILogger<CreateOrderServiceCommandHandler>>();

        //act

        var handler =  new CreateOrderServiceCommandHandler(loggerMock.Object);
        var cltToken = new System.Threading.CancellationToken();

        var result = await handler.Handle(fakeOrderServiceCommand,cltToken);

        //assert
        Assert.True(result);

    }

    public CreateOrderServiceCommand FakeOrderServiceRequest(Dictionary<string,object> args = null){

        return new CreateOrderServiceCommand(
            customerId: args != null && args.ContainsKey("customerId") ? (int)args["customerId"] : 122,
            serviceName: args != null && args.ContainsKey("serviceName") ? (string)args["serviceName"] : "Fake service name",
            serviceDescription: args != null && args.ContainsKey("serviceDescription") ? (string)args["serviceDescription"] : "Fake service description",
            responseTime:args != null && args.ContainsKey("responseTime") ? (TimeSpan)args["responseTime"] : TimeSpan.MinValue,
            requiredProduts:args != null && args.ContainsKey("requiredProduts") ? (List<RequiredProductDTO>)args["requiredProduts"] : new List<RequiredProductDTO>() {new RequiredProductDTO(){Id = 1,Description = "Product fake",Checked = true}}
        );
    }
}