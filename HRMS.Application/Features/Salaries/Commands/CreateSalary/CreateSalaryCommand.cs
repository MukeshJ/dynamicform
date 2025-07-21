using HRMS.Application.DTOs;
using MediatR;

namespace HRMS.Application.Features.Salaries.Commands.CreateSalary;

public class CreateSalaryCommand : IRequest<SalaryDto>
{
    public Guid EmployeeId { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal? Allowances { get; set; }
    public decimal? Deductions { get; set; }
    public DateTime EffectiveDate { get; set; }
    public string? Comments { get; set; }
}