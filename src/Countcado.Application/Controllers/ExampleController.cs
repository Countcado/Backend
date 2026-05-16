using Countcado.Application.DTOs;
using Countcado.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Countcado.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IExampleService _exampleService;

    public ExampleController(IExampleService exampleService)
    {
        _exampleService = exampleService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ExampleDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _exampleService.GetAllAsync(cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ExampleDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _exampleService.GetByIdAsync(id, cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ExampleDto>> Create([FromBody] CreateExampleDto dto, CancellationToken cancellationToken)
    {
        var result = await _exampleService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateExampleDto dto, CancellationToken cancellationToken)
    {
        await _exampleService.UpdateAsync(id, dto, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _exampleService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
