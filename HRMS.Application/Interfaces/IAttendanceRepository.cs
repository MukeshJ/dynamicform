using HRMS.Domain.Entities;

namespace HRMS.Application.Interfaces;

public interface IAttendanceRepository : IGenericRepository<Attendance>
{
    Task<IEnumerable<Attendance>> GetByEmployeeIdAsync(Guid employeeId);
    Task<IEnumerable<Attendance>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<Attendance?> GetByEmployeeAndDateAsync(Guid employeeId, DateTime date);
}