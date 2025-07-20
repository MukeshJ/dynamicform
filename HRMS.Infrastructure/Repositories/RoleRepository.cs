using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(HRMSDbContext context) : base(context)
    {
    }

    public async Task<Role?> GetByNameAsync(string name)
    {
        return await _dbSet
            .FirstOrDefaultAsync(r => r.Name == name && !r.IsDeleted);
    }

    public async Task<IEnumerable<Role>> GetWithEmployeesAsync()
    {
        return await _dbSet
            .Include(r => r.Employees)
            .Where(r => !r.IsDeleted)
            .ToListAsync();
    }
}