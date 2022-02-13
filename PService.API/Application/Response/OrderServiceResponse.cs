using PsService.Domain;

namespace PsService.API;

public class OrderServiceResponse{

    
    public static OrderServiceResponse FromOrderService(OrderService order){

        return new OrderServiceResponse(){};
    }

}