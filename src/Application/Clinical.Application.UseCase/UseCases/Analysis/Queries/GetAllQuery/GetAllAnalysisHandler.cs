using AutoMapper;
using Clinical.Application.Dtos.Analysis.Response;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;

public class GetAllAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAnalysisHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>();

        try
        {
            var analysis = await _unitOfWork.Analysis.GetAllAsync(StoredProcedure.USPANALYSISLIST);

            if (analysis is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<GetAllAnalysisResponseDto>>(analysis);
                response.Message = GlobalMessages.MESSAGE_QUERY;;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}