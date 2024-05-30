using AutoMapper;
using Clinical.Application.Dtos.Patient.Response;
using Clinical.Application.UseCase.UseCases.Patient.Commands.ChangeStateCommand;
using Clinical.Application.UseCase.UseCases.Patient.Commands.CreateCommand;
using Clinical.Application.UseCase.UseCases.Patient.Commands.UpdateCommand;
using Clinical.Domain.Entities;

namespace Clinical.Application.UseCase.Mappings;

public class PatientMappingProfile : Profile
{
    public PatientMappingProfile()
    {
        CreateMap<GetAllPatientResponseDto, Patient>().ReverseMap();
        CreateMap<GetPatientByIdResponseDto, Patient>().ReverseMap();
        CreateMap<CreatePatientCommand, Patient>().ReverseMap();
        CreateMap<UpdatePatientCommand, Patient>().ReverseMap();
        CreateMap<ChangePatientStateComand, Patient>().ReverseMap();
    }
}