using AutoMapper;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using Clinical.Utilities.HelperExtensions;
using MediatR;
using Entity = Clinical.Domain.Entities;

namespace Clinical.Application.UseCase.UseCases.Patient.Commands.UpdateCommand;

public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdatePatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var patient = _mapper.Map<Entity.Patient>(request);
            var parameters = patient.GetPropertiesWithValues();
            response.Data = await _unitOfWork.Patient.ExecuteAsync(StoredProcedure.USPPATIENTEDIT, parameters);

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