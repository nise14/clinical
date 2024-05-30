using AutoMapper;
using Clinical.Application.Dtos.Exam.Response;
using Clinical.Application.UseCase.UseCases.Exam.Commands.ChangeStateExamCommand;
using Clinical.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using Clinical.Application.UseCase.UseCases.Exam.Commands.UpdateCommand;
using Clinical.Domain.Entities;

namespace Clinical.Application.UseCase.Mappings;

public class ExamMappingProfile : Profile
{
    public ExamMappingProfile()
    {
        CreateMap<Exam, GetExamByIdResponseDto>().ReverseMap();
        CreateMap<CreateExamCommand, Exam>();
        CreateMap<UpdateExamCommand, Exam>();
        CreateMap<ChangeStateExamCommand, Exam>();
    }
}