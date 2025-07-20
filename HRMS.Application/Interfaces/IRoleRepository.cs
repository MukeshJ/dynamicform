using HRMS.Domain.Entities;

namespace HRMS.Application.Interfaces;

public interface IRoleRepository : IGenericRepository<Role>
{
    Task<Role?> GetByNameAsync(string name);
    Task<IEnumerable<Role>> GetWithEmployeesAsync();
}