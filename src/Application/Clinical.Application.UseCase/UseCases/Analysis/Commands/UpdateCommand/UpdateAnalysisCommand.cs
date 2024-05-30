using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;

public class UpdateAnalysisCommand : IRequest<BaseResponse<bool>>
{
    public int AnalysisId { get; set; }
    public string? Name { get; set; }
}