using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using HRMS.Domain.Enums;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HRMSDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<LeaveRequest>> GetByEmployeeIdAsync(Guid employeeId)
    {
        return await _dbSet
            .Include(l => l.Employee)
            .Include(l => l.ApprovedBy)
            .Where(l => l.EmployeeId == employeeId && !l.IsDeleted)
            .OrderByDescending(l => l.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<LeaveRequest>> GetByStatusAsync(LeaveStatus status)
    {
        return await _dbSet
            .Include(l => l.Employee)
            .Include(l => l.ApprovedBy)
            .Where(l => l.Status == status && !l.IsDeleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<LeaveRequest>> GetPendingRequestsAsync()
    {
        return await _dbSet
            .Include(l => l.Employee)
            .Where(l => l.Status == LeaveStatus.Pending && !l.IsDeleted)
            .OrderBy(l => l.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<LeaveRequest>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Include(l => l.Employee)
            .Include(l => l.ApprovedBy)
            .Where(l => l.StartDate <= endDate && l.EndDate >= startDate && !l.IsDeleted)
            .ToListAsync();
    }
}