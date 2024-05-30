using AutoMapper;
using Clinical.Application.Dtos.Medic;
using Clinical.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using Clinical.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;
using Clinical.Domain.Entities;

namespace Clinical.Application.UseCase.Mappings;

public class MedicMappingProfile : Profile
{
    public MedicMappingProfile()
    {
        CreateMap<Medic, GetAllMedicResponseDto>();
        CreateMap<Medic, GetMedicByIdResponseDto>().ReverseMap();
        CreateMap<Medic, CreateMedicCommand>().ReverseMap();
        CreateMap<UpdateMedicCommand, Medic>().ReverseMap();
    }
}