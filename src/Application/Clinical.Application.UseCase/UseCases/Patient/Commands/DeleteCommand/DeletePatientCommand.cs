using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Patient.Commands.DeleteCommand;

public class DeletePatientCommand:IRequest<BaseResponse<bool>>
{
    public int PatientId { get; set; }
}