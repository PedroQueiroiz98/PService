using MediatR;
using PS.Domain.OderContext.Aggregates.OrderService;
using PS.Domain.OrderContext.Aggregates.OrderService;

namespace PS.API.Application.Commands.Order;


public class CreateOrderServiceCommandHandler : IRequestHandler<CreateOrderServiceCommand, bool>
{

    private readonly ILogger<CreateOrderServiceCommandHandler> _logger;
    public CreateOrderServiceCommandHandler(ILogger<CreateOrderServiceCommandHandler> logger)
    {

        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    }
    public async Task<bool> Handle(CreateOrderServiceCommand request, CancellationToken cancellationToken)
    {
        

        var requiredProducts = request.RequiredProductDTOs.Select(x=>new RequiredProduct(x.Description,x.Checked)).ToList();
        var oder = OrderService.Create(request.CustomerId,request.ServiceName,request.ServiceDescription,request.ResponseTime,requiredProducts);
    

        return await Task.FromResult(false);

    }
}