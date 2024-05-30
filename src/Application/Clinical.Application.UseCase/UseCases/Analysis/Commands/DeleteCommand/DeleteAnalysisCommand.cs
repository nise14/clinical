using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;

public class DeleteAnalysisCommand : IRequest<BaseResponse<bool>>
{
    public int AnalysisId { get; set; }
}