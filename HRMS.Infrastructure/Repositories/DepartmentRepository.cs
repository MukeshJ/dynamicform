using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(HRMSDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Department>> GetWithEmployeesAsync()
    {
        return await _dbSet
            .Include(d => d.Employees)
            .Include(d => d.Manager)
            .Where(d => !d.IsDeleted)
            .ToListAsync();
    }

    public async Task<Department?> GetWithEmployeesAsync(Guid id)
    {
        return await _dbSet
            .Include(d => d.Employees)
            .Include(d => d.Manager)
            .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
    }

    public async Task<IEnumerable<Department>> GetByManagerAsync(Guid managerId)
    {
        return await _dbSet
            .Include(d => d.Manager)
            .Where(d => d.ManagerId == managerId && !d.IsDeleted)
            .ToListAsync();
    }
}