using AutoMapper;
using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using MediatR;

namespace HRMS.Application.Features.Salaries.Commands.CreateSalary;

public class CreateSalaryHandler : IRequestHandler<CreateSalaryCommand, SalaryDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateSalaryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SalaryDto> Handle(CreateSalaryCommand request, CancellationToken cancellationToken)
    {
        // Check if employee exists
        var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.EmployeeId);
        if (employee == null)
        {
            throw new ArgumentException("Employee not found", nameof(request.EmployeeId));
        }

        // Deactivate any existing active salary for this employee
        var existingActiveSalary = await _unitOfWork.SalaryRepository.GetActiveByEmployeeIdAsync(request.EmployeeId);
        if (existingActiveSalary != null)
        {
            existingActiveSalary.IsActive = false;
            existingActiveSalary.EndDate = request.EffectiveDate.AddDays(-1);
            _unitOfWork.SalaryRepository.Update(existingActiveSalary);
        }

        // Calculate gross and net salary
        var grossSalary = request.BasicSalary + (request.Allowances ?? 0);
        var netSalary = grossSalary - (request.Deductions ?? 0);

        // Create new salary record
        var salary = new Salary
        {
            EmployeeId = request.EmployeeId,
            BasicSalary = request.BasicSalary,
            Allowances = request.Allowances,
            Deductions = request.Deductions,
            GrossSalary = grossSalary,
            NetSalary = netSalary,
            EffectiveDate = request.EffectiveDate,
            IsActive = true,
            Comments = request.Comments
        };

        await _unitOfWork.SalaryRepository.AddAsync(salary);
        await _unitOfWork.CompleteAsync();

        // Get the created salary with employee information
        var createdSalary = await _unitOfWork.SalaryRepository.GetByIdAsync(salary.Id);
        return _mapper.Map<SalaryDto>(createdSalary);
    }
}