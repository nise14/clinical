using AutoMapper;
using Clinical.Application.Dtos.Analysis.Response;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;

public class GetAnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAnalysisByIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<GetAnalysisByIdResponseDto>();

        try
        {
            var analysis = await _unitOfWork.Analysis.GetByIdAsync(StoredProcedure.USPANALYSISBYID, request);

            if (analysis is null)
            {
                response.IsSuccess = false;
                response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
            response.Message = GlobalMessages.MESSAGE_QUERY;;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}