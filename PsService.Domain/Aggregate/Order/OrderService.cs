using PsService.Domain.Shared;

namespace PsService.Domain;


public class OrderService : Entity , IAggregateRoot{

    private int  _customerId {get;set;}
    public string ServiceName {get;set;}
    public string ServiceDescription {get;set;} 
    protected OrderService(){}
    public OrderService(int customerId,string serviceName,string serviceDescription){


        _customerId = customerId;
        ServiceName = serviceName;
        ServiceDescription = serviceDescription;
    }

}