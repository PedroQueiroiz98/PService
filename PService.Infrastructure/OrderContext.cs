using Microsoft.EntityFrameworkCore;
using PsService.Domain;
using PsService.Domain.Shared;

namespace PService.Infrastructure;
public class OrderContext :DbContext , IUnitOfWork
{
    public DbSet<OrderService> OrderServices { get; set; }
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {

    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return true;
    }
}
