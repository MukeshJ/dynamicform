using HRMS.Application.DTOs;
using HRMS.Application.Features.Employees.Commands.CreateEmployee;
using HRMS.Application.Features.Employees.Queries.GetAllEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployee), new { id = result.Id }, result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployee(Guid id)
    {
        // This would use a GetEmployeeQuery - we'll implement this later
        return Ok($"Get employee with ID: {id}");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
    {
        try
        {
            var query = new GetAllEmployeesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
        // This would use an UpdateEmployeeCommand - we'll implement this later
        return Ok($"Update employee with ID: {id}");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(Guid id)
    {
        // This would use a DeleteEmployeeCommand - we'll implement this later
        return Ok($"Delete employee with ID: {id}");
    }
}