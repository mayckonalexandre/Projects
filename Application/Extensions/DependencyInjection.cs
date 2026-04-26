using Application.Modules;
using Application.Modules.Users.Services;
using Application.Modules.Users.UseCases.Command;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Services
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        //Use Cases
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
        return services;
    }
}