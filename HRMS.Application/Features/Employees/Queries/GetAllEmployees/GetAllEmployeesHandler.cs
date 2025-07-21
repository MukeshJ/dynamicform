using AutoMapper;
using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using MediatR;

namespace HRMS.Application.Features.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllEmployeesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _unitOfWork.EmployeeRepository.GetWithDepartmentAndRoleAsync();
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }
}