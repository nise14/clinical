using Clinical.Application.Dtos.Analysis.Response;
using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;

public class GetAnalysisByIdQuery : IRequest<BaseResponse<GetAnalysisByIdResponseDto>>
{
    public int AnalysisId { get; set; }
}