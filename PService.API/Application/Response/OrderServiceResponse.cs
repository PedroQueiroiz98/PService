using PsService.Domain;

namespace PsService.API;

public class OrderServiceResponse{

    public int Id {get;set;}

    public string ServiceName {get;set;}
    public string ServiceDescription {get;set;}
    public static OrderServiceResponse FromOrderService(OrderService order){

        return new OrderServiceResponse(){
            Id = order.Id,
            ServiceName = order.ServiceName,
            ServiceDescription = order.ServiceDescription
        };
    }

}