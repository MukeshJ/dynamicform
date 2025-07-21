using HRMS.Domain.Enums;

namespace HRMS.Domain.Entities;

public class Employee : BaseEntity
{
    public string EmployeeId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public string Position { get; set; } = string.Empty;
    public EmployeeStatus Status { get; set; }
    public string Address { get; set; } = string.Empty;
    
    // Foreign Keys
    public Guid DepartmentId { get; set; }
    public Guid RoleId { get; set; }
    
    // Navigation Properties
    public Department Department { get; set; } = null!;
    public Role Role { get; set; } = null!;
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    public ICollection<Salary> Salaries { get; set; } = new List<Salary>();
}