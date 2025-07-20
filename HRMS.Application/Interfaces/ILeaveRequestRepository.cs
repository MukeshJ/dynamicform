using HRMS.Domain.Entities;
using HRMS.Domain.Enums;

namespace HRMS.Application.Interfaces;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<IEnumerable<LeaveRequest>> GetByEmployeeIdAsync(Guid employeeId);
    Task<IEnumerable<LeaveRequest>> GetByStatusAsync(LeaveStatus status);
    Task<IEnumerable<LeaveRequest>> GetPendingRequestsAsync();
    Task<IEnumerable<LeaveRequest>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
}