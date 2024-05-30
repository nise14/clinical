using Clinical.Application.UseCase.UseCases.Patient.Commands.ChangeStateCommand;
using Clinical.Application.UseCase.UseCases.Patient.Commands.CreateCommand;
using Clinical.Application.UseCase.UseCases.Patient.Commands.DeleteCommand;
using Clinical.Application.UseCase.UseCases.Patient.Commands.UpdateCommand;
using Clinical.Application.UseCase.UseCases.Patient.Queries.GetAllQuery;
using Clinical.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinical.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ListPatient")]
    public async Task<IActionResult> ListPatient()
    {
        var response = await _mediator.Send(new GetAllPatientQuery());
        return Ok(response);
    }

    [HttpGet("{patientId:int}")]
    public async Task<IActionResult> PatientById(int patientId)
    {
        var response = await _mediator.Send(new GetPatientByIdQuery { PatientId = patientId });
        return Ok(response);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterPatient([FromBody] CreatePatientCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("Edit")]
    public async Task<IActionResult> EditPatient([FromBody] UpdatePatientCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);    
    }

    [HttpDelete("Remove/{patientId:int}")]
    public async Task<IActionResult> DeletePatient(int patientId)
    {
        var response = await _mediator.Send(new DeletePatientCommand { PatientId = patientId });
        return Ok(response);
    }

    [HttpPut("ChangeState")]
    public async Task<IActionResult> ChangeStatePatient([FromBody] ChangePatientStateComand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}