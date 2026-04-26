using Application.Services.User;
using Application.UseCases.CreateUser;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Services
        services.AddScoped<IUserService, UserService>();

        //Use Cases
        services.AddScoped<ICreateUser, CreateUser>();

        return services;
    }
}