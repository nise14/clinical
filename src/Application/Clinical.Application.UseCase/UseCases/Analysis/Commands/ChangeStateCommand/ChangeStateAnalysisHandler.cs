using AutoMapper;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using Clinical.Utilities.HelperExtensions;
using MediatR;
using Entity = Clinical.Domain.Entities;

namespace Clinical.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;

public class ChangeStateAnalysisHandler : IRequestHandler<ChangeStateAnalysisCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChangeStateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(ChangeStateAnalysisCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var analysis = _mapper.Map<Entity.Analysis>(request);
            var parameters = analysis.GetPropertiesWithValues();
            response.Data = await _unitOfWork.Analysis.ExecuteAsync(StoredProcedure.USPANALYSISCHANGESTATE, parameters);

            if (response.Data)
            {
                response.IsSuccess = false;
                response.Message = GlobalMessages.MESSAGE_UPDATE_STATE;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.ToString();
        }

        return response;
    }
}