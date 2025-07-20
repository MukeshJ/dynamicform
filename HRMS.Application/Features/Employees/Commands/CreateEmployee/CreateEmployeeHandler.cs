using AutoMapper;
using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using MediatR;

namespace HRMS.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        // Check if employee ID already exists
        var existingEmployee = await _unitOfWork.EmployeeRepository.GetByEmployeeIdAsync(request.EmployeeId);
        if (existingEmployee != null)
        {
            throw new InvalidOperationException($"Employee with ID {request.EmployeeId} already exists.");
        }

        // Check if email already exists
        var existingEmailEmployee = await _unitOfWork.EmployeeRepository.GetByEmailAsync(request.Email);
        if (existingEmailEmployee != null)
        {
            throw new InvalidOperationException($"Employee with email {request.Email} already exists.");
        }

        // Verify department exists
        var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(request.DepartmentId);
        if (department == null)
        {
            throw new InvalidOperationException($"Department with ID {request.DepartmentId} not found.");
        }

        // Verify role exists
        var role = await _unitOfWork.RoleRepository.GetByIdAsync(request.RoleId);
        if (role == null)
        {
            throw new InvalidOperationException($"Role with ID {request.RoleId} not found.");
        }

        var employee = _mapper.Map<Employee>(request);
        employee.Id = Guid.NewGuid();
        employee.CreatedAt = DateTime.UtcNow;

        await _unitOfWork.EmployeeRepository.AddAsync(employee);
        await _unitOfWork.CompleteAsync();

        var employeeDto = _mapper.Map<EmployeeDto>(employee);
        employeeDto.DepartmentName = department.Name;
        employeeDto.RoleName = role.Name;

        return employeeDto;
    }
}