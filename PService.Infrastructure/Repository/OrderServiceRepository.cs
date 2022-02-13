using Microsoft.EntityFrameworkCore;
using PsService.Domain;
using PsService.Domain.Shared;

namespace PService.Infrastructure.Repository;

public class OrderServiceRepository : IOrderServiceRepository
{

    private readonly OrderContext _context;
    public IUnitOfWork UnitOfWork
    {
        get
        {
            return _context;
        }
    }

    public OrderServiceRepository(OrderContext context){
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public OrderService Add(OrderService order)
    {
        return _context.OrderServices.Add(order).Entity;
    }
    public async Task<OrderService?> GetOrderAsync(int id)
    {
        var order = await _context.OrderServices.FirstOrDefaultAsync(x=>x.Id.Equals(id));
        if(order is null)order = _context.OrderServices.Local.FirstOrDefault(x=>x.Id.Equals(id));
        return order;
    }
}
