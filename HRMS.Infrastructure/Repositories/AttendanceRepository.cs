using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories;

public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
{
    public AttendanceRepository(HRMSDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Attendance>> GetByEmployeeIdAsync(Guid employeeId)
    {
        return await _dbSet
            .Include(a => a.Employee)
            .Where(a => a.EmployeeId == employeeId && !a.IsDeleted)
            .OrderByDescending(a => a.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Attendance>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Include(a => a.Employee)
            .Where(a => a.Date >= startDate && a.Date <= endDate && !a.IsDeleted)
            .ToListAsync();
    }

    public async Task<Attendance?> GetByEmployeeAndDateAsync(Guid employeeId, DateTime date)
    {
        return await _dbSet
            .Include(a => a.Employee)
            .FirstOrDefaultAsync(a => a.EmployeeId == employeeId && a.Date.Date == date.Date && !a.IsDeleted);
    }
}