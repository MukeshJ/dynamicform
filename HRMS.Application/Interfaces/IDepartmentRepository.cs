using HRMS.Domain.Entities;

namespace HRMS.Application.Interfaces;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    Task<IEnumerable<Department>> GetWithEmployeesAsync();
    Task<Department?> GetWithEmployeesAsync(Guid id);
    Task<IEnumerable<Department>> GetByManagerAsync(Guid managerId);
}