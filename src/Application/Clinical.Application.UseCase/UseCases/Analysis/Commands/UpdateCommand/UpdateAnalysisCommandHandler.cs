using AutoMapper;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using Clinical.Utilities.HelperExtensions;
using MediatR;
using Entity = Clinical.Domain.Entities;

namespace Clinical.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;

public class UpdateAnalysisCommandHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAnalysisCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var analysis = _mapper.Map<Entity.Analysis>(request);
            var parameters = analysis.GetPropertiesWithValues();
            response.Data = await _unitOfWork.Analysis.ExecuteAsync(StoredProcedure.USPANALYSISEDIT, parameters);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGE_UPDATE;;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}