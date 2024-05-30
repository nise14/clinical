using Clinical.Application.Dtos.Medic;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;

public class GetAllMedicHandler : IRequestHandler<GetAllMedicQuery, BaseResponse<IEnumerable<GetAllMedicResponseDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMedicHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<IEnumerable<GetAllMedicResponseDto>>> Handle(GetAllMedicQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<GetAllMedicResponseDto>>();

        try
        {
            var medics = await _unitOfWork.Medic.GetAllMedicsAsync(StoredProcedure.USPMEDICLIST);

            if (medics is not null)
            {
                response.IsSuccess = true;
                response.Data = medics;
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