using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;

public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
{
    public string? Name { get; set; }
}