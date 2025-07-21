using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using HRMS.Domain.Enums;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(HRMSDbContext context) : base(context)
    {
    }

    public async Task<Employee?> GetByEmployeeIdAsync(string employeeId)
    {
        return await _dbSet
            .Include(e => e.Department)
            .Include(e => e.Role)
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && !e.IsDeleted);
    }

    public async Task<Employee?> GetByEmailAsync(string email)
    {
        return await _dbSet
            .Include(e => e.Department)
            .Include(e => e.Role)
            .FirstOrDefaultAsync(e => e.Email == email && !e.IsDeleted);
    }

    public async Task<IEnumerable<Employee>> GetByDepartmentAsync(Guid departmentId)
    {
        return await _dbSet
            .Include(e => e.Department)
            .Include(e => e.Role)
            .Where(e => e.DepartmentId == departmentId && !e.IsDeleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetByStatusAsync(EmployeeStatus status)
    {
        return await _dbSet
            .Include(e => e.Department)
            .Include(e => e.Role)
            .Where(e => e.Status == status && !e.IsDeleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetWithDepartmentAndRoleAsync()
    {
        return await _dbSet
            .Include(e => e.Department)
            .Include(e => e.Role)
            .Where(e => !e.IsDeleted)
            .ToListAsync();
    }

    public async Task<Employee?> GetWithDepartmentAndRoleAsync(Guid id)
    {
        return await _dbSet
            .Include(e => e.Department)
            .Include(e => e.Role)
            .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
    }

    public async Task<IEnumerable<Employee>> SearchAsync(string searchTerm)
    {
        return await _dbSet
            .Include(e => e.Department)
            .Include(e => e.Role)
            .Where(e => !e.IsDeleted && 
                (e.FirstName.Contains(searchTerm) || 
                 e.LastName.Contains(searchTerm) || 
                 e.Email.Contains(searchTerm) || 
                 e.EmployeeId.Contains(searchTerm)))
            .ToListAsync();
    }
}