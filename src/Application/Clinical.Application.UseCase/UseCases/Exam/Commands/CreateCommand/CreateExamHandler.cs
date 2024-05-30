using AutoMapper;
using Clinical.Application.Interface.Interfaces;
using Clinical.Application.UseCase.Common.Base;
using Clinical.Utilities.Constants;
using Clinical.Utilities.HelperExtensions;
using MediatR;
using Entity = Clinical.Domain.Entities;

namespace Clinical.Application.UseCase.UseCases.Exam.Commands.CreateCommand;

public class CreateCommand : IRequestHandler<CreateExamCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCommand(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var exam = _mapper.Map<Entity.Exam>(request);
            var parameters = exam.GetPropertiesWithValues();
            response.Data = await _unitOfWork.Exam.ExecuteAsync(StoredProcedure.USPEXAMREGISTER, parameters: parameters);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGE_SAVE;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}