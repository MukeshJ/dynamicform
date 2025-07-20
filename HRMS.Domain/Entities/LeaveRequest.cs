using HRMS.Domain.Enums;

namespace HRMS.Domain.Entities;

public class LeaveRequest : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalDays { get; set; }
    public string Reason { get; set; } = string.Empty;
    public LeaveStatus Status { get; set; }
    public Guid? ApprovedById { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? ApprovalComments { get; set; }
    
    // Navigation Properties
    public Employee Employee { get; set; } = null!;
    public Employee? ApprovedBy { get; set; }
}