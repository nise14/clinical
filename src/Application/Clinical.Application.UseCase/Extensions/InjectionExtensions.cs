using System.Reflection;
using Clinical.Application.UseCase.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Clinical.Application.UseCase.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehaviour<,>));
        return services;
    }
}