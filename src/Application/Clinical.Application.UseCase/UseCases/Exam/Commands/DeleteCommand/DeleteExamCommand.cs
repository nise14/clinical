using Clinical.Application.UseCase.Common.Base;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Exam.Commands.DeleteCommand;

public class DeleteExamCommand:IRequest<BaseResponse<bool>>
{
    public int ExamId { get; set; }
}