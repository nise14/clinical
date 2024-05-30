using Clinical.Application.Dtos.Exam.Response;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Exam.Queries.GetAllQuery;

public class GetAllExamHandler : IRequestHandler<GetAllExamQuery, BaseResponse<IEnumerable<GetAllExamResponseDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllExamHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<IEnumerable<GetAllExamResponseDto>>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<GetAllExamResponseDto>>();

        try
        {
            var exams = await _unitOfWork.Exam.GetAllExamsAsync(StoredProcedure.USPEXAMLIST);

            if (exams is not null)
            {
                response.IsSuccess = true;
                response.Data = exams;
                response.Message = GlobalMessages.MESSAGE_QUERY;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}