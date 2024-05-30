using Clinical.Application.Dtos.Patient.Response;
using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Patient.Queries.GetAllQuery;

public class GetAllPatientQuery : IRequest<BaseResponse<IEnumerable<GetAllPatientResponseDto>>>
{
}