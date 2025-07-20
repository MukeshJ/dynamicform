using HRMS.Domain.Entities;

namespace HRMS.Application.Interfaces;

public interface ISalaryRepository : IGenericRepository<Salary>
{
    Task<IEnumerable<Salary>> GetByEmployeeIdAsync(Guid employeeId);
    Task<Salary?> GetActiveByEmployeeIdAsync(Guid employeeId);
    Task<IEnumerable<Salary>> GetActiveSalariesAsync();
    Task<Salary?> GetLatestByEmployeeIdAsync(Guid employeeId);
}