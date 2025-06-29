using Application.Interface;
using Application.Mapper.CustomersProfile;
using Domain.entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CustomerMapping));
        
        return services;
    }
}