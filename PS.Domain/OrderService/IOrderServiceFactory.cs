namespace PS.Domain.OrderService;


public interface IOrderServiceFactory{

    OrderService Make(Customer.Customer customer,Service.Service service);

}