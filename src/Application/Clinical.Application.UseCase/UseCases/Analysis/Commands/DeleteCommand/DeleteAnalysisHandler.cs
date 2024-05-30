using Clinical.Application.Interface;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;

public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAnalysisHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            response.Data = await _unitOfWork.Analysis.ExecuteAsync(StoredProcedure.USPANALYSISREMOVE, request);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGE_DELETE;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}