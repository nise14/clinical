using Clinical.Application.Interface.Interfaces;
using Clinical.Persistence.Context;
using Clinical.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Clinical.Persistence.Extensions;

public static class InjectionExtension
{
    public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
    {
        services.AddSingleton<ApplicationDbContext>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAnalysisRepository, AnalysisRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IMedicRepository,MedicRepository>();
        
        return services;
    }
}