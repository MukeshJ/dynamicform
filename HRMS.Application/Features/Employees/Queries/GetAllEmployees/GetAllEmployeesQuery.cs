using HRMS.Application.DTOs;
using MediatR;

namespace HRMS.Application.Features.Employees.Queries.GetAllEmployees;

public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
{
    // This is a simple query with no parameters
}