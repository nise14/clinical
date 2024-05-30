using AutoMapper;
using Clinical.Application.Dtos.Medic;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using MediatR;

namespace Clinical.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery;

public class GetMedicByIdHandler : IRequestHandler<GetMedicByIdQuery, BaseResponse<GetMedicByIdResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMedicByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetMedicByIdResponseDto>> Handle(GetMedicByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<GetMedicByIdResponseDto>();

        try
        {
            var medic = await _unitOfWork.Medic.GetByIdAsync(StoredProcedure.USPMEDICBYID, request);

            if (medic is null)
            {
                response.IsSuccess = false;
                response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<GetMedicByIdResponseDto>(medic);
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