using Clinical.Application.Dtos.Patient.Response;
using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery;

public class GetPatientByIdQuery : IRequest<BaseResponse<GetPatientByIdResponseDto>>
{
    public int PatientId { get; set; }
}