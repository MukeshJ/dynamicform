namespace HRMS.Application.DTOs;

public class SalaryDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public decimal BasicSalary { get; set; }
    public decimal? Allowances { get; set; }
    public decimal? Deductions { get; set; }
    public decimal GrossSalary { get; set; }
    public decimal NetSalary { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; }
    public string? Comments { get; set; }
}

public class CreateSalaryDto
{
    public Guid EmployeeId { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal? Allowances { get; set; }
    public decimal? Deductions { get; set; }
    public DateTime EffectiveDate { get; set; }
    public string? Comments { get; set; }
}

public class UpdateSalaryDto
{
    public Guid Id { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal? Allowances { get; set; }
    public decimal? Deductions { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; }
    public string? Comments { get; set; }
}