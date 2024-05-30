using Clinical.Application.Dtos.Medic;
using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;

public class GetAllMedicQuery:IRequest<BaseResponse<IEnumerable<GetAllMedicResponseDto>>>
{
    
}