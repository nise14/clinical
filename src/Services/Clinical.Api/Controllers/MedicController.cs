using Clinical.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using Clinical.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;
using Clinical.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;
using Clinical.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinical.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ListMedics")]
    public async Task<IActionResult> ListMedics()
    {
        var response = await _mediator.Send(new GetAllMedicQuery());
        return Ok(response);
    }

    [HttpGet("{medicId:int}")]
    public async Task<IActionResult> MedicById(int medicId)
    {
        var respone = await _mediator.Send(new GetMedicByIdQuery { MedicId = medicId });
        return Ok(respone);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterMedic([FromBody] CreateMedicCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("Edit")]
    public async Task<IActionResult> UpdateMedic([FromBody] UpdateMedicCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}