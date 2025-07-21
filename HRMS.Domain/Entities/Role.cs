namespace HRMS.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Permissions { get; set; } = string.Empty; // JSON string of permissions
    
    // Navigation Properties
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}