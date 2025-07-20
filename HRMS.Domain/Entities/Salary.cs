namespace HRMS.Domain.Entities;

public class Salary : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal? Allowances { get; set; }
    public decimal? Deductions { get; set; }
    public decimal GrossSalary { get; set; }
    public decimal NetSalary { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; }
    public string? Comments { get; set; }
    
    // Navigation Properties
    public Employee Employee { get; set; } = null!;
}