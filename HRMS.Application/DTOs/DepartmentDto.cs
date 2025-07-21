namespace HRMS.Application.DTOs;

public class DepartmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid? ManagerId { get; set; }
    public string? ManagerName { get; set; }
    public int EmployeeCount { get; set; }
}

public class CreateDepartmentDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid? ManagerId { get; set; }
}

public class UpdateDepartmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid? ManagerId { get; set; }
}