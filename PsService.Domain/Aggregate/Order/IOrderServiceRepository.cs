using PsService.Domain.Shared;

namespace PsService.Domain;

public interface IOrderServiceRepository : IRepository<OrderService>{

    Task Add(OrderService order);
    Task<OrderService> GetOrderAsync(int id);
}