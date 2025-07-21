namespace HRMS.Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid? ManagerId { get; set; }
    
    // Navigation Properties
    public Employee? Manager { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}