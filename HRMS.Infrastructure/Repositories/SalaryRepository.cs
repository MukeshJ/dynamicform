using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories;

public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
{
    public SalaryRepository(HRMSDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Salary>> GetByEmployeeIdAsync(Guid employeeId)
    {
        return await _dbSet
            .Include(s => s.Employee)
            .Where(s => s.EmployeeId == employeeId && !s.IsDeleted)
            .OrderByDescending(s => s.EffectiveDate)
            .ToListAsync();
    }

    public async Task<Salary?> GetActiveByEmployeeIdAsync(Guid employeeId)
    {
        return await _dbSet
            .Include(s => s.Employee)
            .FirstOrDefaultAsync(s => s.EmployeeId == employeeId && s.IsActive && !s.IsDeleted);
    }

    public async Task<IEnumerable<Salary>> GetActiveSalariesAsync()
    {
        return await _dbSet
            .Include(s => s.Employee)
            .Where(s => s.IsActive && !s.IsDeleted)
            .ToListAsync();
    }

    public async Task<Salary?> GetLatestByEmployeeIdAsync(Guid employeeId)
    {
        return await _dbSet
            .Include(s => s.Employee)
            .Where(s => s.EmployeeId == employeeId && !s.IsDeleted)
            .OrderByDescending(s => s.EffectiveDate)
            .FirstOrDefaultAsync();
    }
}