using PS.Domain.Shared;

namespace PS.Domain.Service;
public interface IServiceRepository : IRepository<Service>{

    Task<Service> FindIdAsync(int id);
}