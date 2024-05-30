using Clinical.Application.Dtos.Analysis.Response;
using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;

public class GetAllAnalysisQuery:IRequest<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
{
    
}