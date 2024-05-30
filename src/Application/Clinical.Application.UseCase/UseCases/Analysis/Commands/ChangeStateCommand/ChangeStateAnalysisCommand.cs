using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;

public class ChangeStateAnalysisCommand: IRequest<BaseResponse<bool>>
{
    public int AnalysisId { get; set; }
    public int State { get; set; }
}