using MediatR;
using PS.Domain.Customer;
using PS.Domain.OrderService;
using PS.Domain.Service;

namespace PS.API.Application.Commands.OrderService;


public class CreateOrderServiceCommandHandler : IRequestHandler<CreateOrderServiceCommand, bool>
{

    private readonly ICustomerRepository _customerRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IOrderServiceRepository _orderServiceRepository;
    private readonly IOrderServiceFactory _orderServiceFactory;
    private readonly ILogger<CreateOrderServiceCommand> _logger;
    public CreateOrderServiceCommandHandler(
        ICustomerRepository customerRepository,
        IServiceRepository serviceRepository,
        IOrderServiceRepository orderServiceRepository,
        IOrderServiceFactory orderServiceFactory,
        ILogger<CreateOrderServiceCommand> logger)
    {

        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
        _orderServiceRepository = orderServiceRepository ?? throw new ArgumentNullException(nameof(orderServiceRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    }
    public async Task<bool> Handle(CreateOrderServiceCommand request, CancellationToken cancellationToken)
    {

        var customer = await _customerRepository.FindIdAsync(request.CustomerId);
        var service = await _serviceRepository.FindIdAsync(request.CustomerId);
        
        var order = _orderServiceFactory.Make(customer,service);

        _logger.LogInformation("----- Creating Order Service - Order Service: {@Order}", order);

        _orderServiceRepository.Add(order);

        return await  _orderServiceRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}