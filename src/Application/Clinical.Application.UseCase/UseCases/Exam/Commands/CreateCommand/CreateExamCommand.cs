using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Exam.Commands.CreateCommand;

public class CreateExamCommand : IRequest<BaseResponse<bool>>
{
    public string? Name { get; set; }
    public int AnalysisId { get; set; }
}