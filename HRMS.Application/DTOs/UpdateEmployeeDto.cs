using HRMS.Domain.Enums;

namespace HRMS.Application.DTOs;

public class UpdateEmployeeDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Position { get; set; } = string.Empty;
    public EmployeeStatus Status { get; set; }
    public string Address { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; }
    public Guid RoleId { get; set; }
}

public class CreateEmployeeDto
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
    public Guid DepartmentId { get; set; }
    public Guid RoleId { get; set; }
}