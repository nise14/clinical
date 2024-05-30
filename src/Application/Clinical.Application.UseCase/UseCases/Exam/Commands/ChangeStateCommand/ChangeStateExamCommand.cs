using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Exam.Commands.ChangeStateExamCommand;

public class ChangeStateExamCommand : IRequest<BaseResponse<bool>>
{
    public int ExamId { get; set; }
    public int State { get; set; }
}