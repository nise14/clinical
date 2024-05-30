using System.Reflection.Metadata;
using AutoMapper;
using Clinical.Application.Dtos.Exam.Response;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery;

public class GetExamByIdHandler : IRequestHandler<GetExamByIdQuery, BaseResponse<GetExamByIdResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetExamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetExamByIdResponseDto>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<GetExamByIdResponseDto>();

        try
        {
            var exam = await _unitOfWork.Exam.GetByIdAsync(StoredProcedure.USPEXAMBYID, request);

            if(exam is null){
                response.IsSuccess = false;
                response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess= true;
            response.Data = _mapper.Map<GetExamByIdResponseDto>(exam);
            response.Message = GlobalMessages.MESSAGE_QUERY;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}