using PS.Domain.OderContext.Aggregates.OrderService;
using PS.Domain.OderContext.Exceptions;
using PS.Domain.Shared;

namespace PS.Domain.OrderContext.Aggregates.OrderService;


public class OrderService : Entity , IAggregateRoot {
    

    private int _customerId;
    public string ServiceName {get;private set;}
    public string ServiceDescription {get;private set;}
    public TimeSpan ResponseTime {get;private set;}
    private List<RequiredProduct> _requiredProducts;
    public IReadOnlyList<RequiredProduct> RequiredProducts=>_requiredProducts.AsReadOnly();

    public OrderService(){

         _requiredProducts = new List<RequiredProduct>();
    }
    private OrderService(int customerId,string serviceName,string serviceDescription,TimeSpan responseTime){

        _customerId = customerId;
        ServiceName = serviceName;
        ServiceDescription = serviceDescription;
        ResponseTime = responseTime;
    }

    public static OrderService Create(int customerId,string serviceName,string serviceDescription,TimeSpan responseTime,List<RequiredProduct> requiredProducts){


        if(!requiredProducts.Any())throw new OrderServiceDomainException(DomainErrors.OrderServiceErrors.RequiredProduct());
        if(!(customerId > 0)) throw new OrderServiceDomainException(DomainErrors.OrderServiceErrors.RequiredCustomer());
        if(String.IsNullOrEmpty(serviceName)) throw new OrderServiceDomainException(DomainErrors.OrderServiceErrors.RequiredServiceName());
        if(String.IsNullOrEmpty(serviceDescription)) throw new OrderServiceDomainException(DomainErrors.OrderServiceErrors.RequiredServiceDescription());
        if(responseTime == TimeSpan.MinValue) throw new OrderServiceDomainException(DomainErrors.OrderServiceErrors.RequiredResponseTime());

        var order = new OrderService();

         foreach (var product in requiredProducts)
         {
             order.AddRequiredProduct(product.Description,product.Checked);
         }   

        return order;

    }
    public void AddRequiredProduct(string description,bool @checked){

        if(!@checked)throw new OrderServiceDomainException($"Product {description} is necessary for create order service");
        _requiredProducts.Add(new RequiredProduct(description,@checked));
    }
}