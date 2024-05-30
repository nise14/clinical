using AutoMapper;
using Clinical.Application.Dtos.Analysis.Response;
using Clinical.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using Clinical.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using Clinical.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using Clinical.Domain.Entities;

namespace Clinical.Application.UseCase.Mappings;

public class AnalysisMappingProfile : Profile
{
    public AnalysisMappingProfile()
    {
        CreateMap<Analysis, GetAllAnalysisResponseDto>()
            .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
            .ReverseMap();

        CreateMap<Analysis, GetAnalysisByIdResponseDto>()
            .ReverseMap();

        CreateMap<CreateAnalysisCommand, Analysis>();

        CreateMap<UpdateAnalysisCommand, Analysis>();

        CreateMap<ChangeStateAnalysisCommand, Analysis>();
    }
}