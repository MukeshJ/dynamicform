using HRMS.Domain.Entities;
using HRMS.Domain.Enums;

namespace HRMS.Application.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<Employee?> GetByEmployeeIdAsync(string employeeId);
    Task<Employee?> GetByEmailAsync(string email);
    Task<IEnumerable<Employee>> GetByDepartmentAsync(Guid departmentId);
    Task<IEnumerable<Employee>> GetByStatusAsync(EmployeeStatus status);
    Task<IEnumerable<Employee>> GetWithDepartmentAndRoleAsync();
    Task<Employee?> GetWithDepartmentAndRoleAsync(Guid id);
    Task<IEnumerable<Employee>> SearchAsync(string searchTerm);
}