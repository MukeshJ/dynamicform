using HRMS.Application.DTOs;
using HRMS.Application.Features.Salaries.Commands.CreateSalary;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalariesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalariesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<SalaryDto>> CreateSalary([FromBody] CreateSalaryCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetSalary), new { id = result.Id }, result);
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
    public async Task<ActionResult<SalaryDto>> GetSalary(Guid id)
    {
        // This would use a GetSalaryQuery - we'll implement this later
        return Ok($"Get salary with ID: {id}");
    }

    [HttpGet("employee/{employeeId}")]
    public async Task<ActionResult<IEnumerable<SalaryDto>>> GetEmployeeSalaries(Guid employeeId)
    {
        // This would use a GetEmployeeSalariesQuery - we'll implement this later
        return Ok($"Get salaries for employee: {employeeId}");
    }

    [HttpGet("employee/{employeeId}/active")]
    public async Task<ActionResult<SalaryDto>> GetActiveEmployeeSalary(Guid employeeId)
    {
        // This would use a GetActiveEmployeeSalaryQuery - we'll implement this later
        return Ok($"Get active salary for employee: {employeeId}");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSalary(Guid id, [FromBody] UpdateSalaryDto updateSalaryDto)
    {
        // This would use an UpdateSalaryCommand - we'll implement this later
        return Ok($"Update salary with ID: {id}");
    }
}