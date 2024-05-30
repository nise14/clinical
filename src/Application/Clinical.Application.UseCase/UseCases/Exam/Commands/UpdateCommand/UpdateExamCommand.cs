using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Exam.Commands.UpdateCommand;

public class UpdateExamCommand : IRequest<BaseResponse<bool>>
{
    public int ExamId { get; set; }
    public string? Name { get; set; }
    public int AnalysisId { get; set; }
}