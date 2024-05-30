using AutoMapper;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using Clinical.Utilities.HelperExtensions;
using MediatR;
using Entity = Clinical.Domain.Entities;

namespace Clinical.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;

public class UpdateMedicHandler : IRequestHandler<UpdateMedicCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(UpdateMedicCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var medic = _mapper.Map<Entity.Medic>(request);
            var parameters = medic.GetPropertiesWithValues();
            response.Data = await _unitOfWork.Medic.ExecuteAsync(StoredProcedure.USPMEDICEDIT, parameters);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGE_UPDATE;
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