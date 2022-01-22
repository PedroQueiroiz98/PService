using PS.Domain.Shared;

namespace PS.Domain.OrderService;

public interface IOrderServiceRepository : IRepository<OrderService>{
    
    OrderService Add(OrderService order);
}