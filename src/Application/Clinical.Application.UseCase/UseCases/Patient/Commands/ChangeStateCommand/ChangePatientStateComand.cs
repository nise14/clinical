using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Patient.Commands.ChangeStateCommand;

public class ChangePatientStateComand : IRequest<BaseResponse<bool>>
{
    public int PatientId { get; set; }
    public int State { get; set; }
}