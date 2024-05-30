using Clinical.Application.Dtos.Medic;
using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery;

public class GetMedicByIdQuery : IRequest<BaseResponse<GetMedicByIdResponseDto>>
{
    public int MedicId { get; set; }
}