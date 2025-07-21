using HRMS.Domain.Enums;

namespace HRMS.Domain.Entities;

public class Attendance : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan? CheckInTime { get; set; }
    public TimeSpan? CheckOutTime { get; set; }
    public TimeSpan? BreakDuration { get; set; }
    public TimeSpan? TotalHours { get; set; }
    public AttendanceStatus Status { get; set; }
    public string? Notes { get; set; }
    
    // Navigation Properties
    public Employee Employee { get; set; } = null!;
}