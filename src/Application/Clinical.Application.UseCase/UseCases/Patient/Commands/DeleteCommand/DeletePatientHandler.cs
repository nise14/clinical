using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Patient.Commands.DeleteCommand;

public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePatientHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            response.Data = await _unitOfWork.Patient.ExecuteAsync(StoredProcedure.USPPATIENTREMOVE, request);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGE_DELETE;
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }

        return response;
    }
}