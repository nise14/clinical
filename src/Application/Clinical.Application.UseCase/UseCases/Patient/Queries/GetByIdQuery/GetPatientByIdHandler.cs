using AutoMapper;
using Clinical.Application.Dtos.Patient.Response;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery;

public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, BaseResponse<GetPatientByIdResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPatientByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetPatientByIdResponseDto>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<GetPatientByIdResponseDto>();

        try
        {
            var patient = await _unitOfWork.Patient.GetByIdAsync(StoredProcedure.USPPATIENTBYID, request);

            if (patient is null)
            {
                response.IsSuccess = false;
                response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess=true;
            response.Data = _mapper.Map<GetPatientByIdResponseDto>(patient);
            response.Message = GlobalMessages.MESSAGE_QUERY;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }

        return response;
    }
}