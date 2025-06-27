using Domain.Interfaces.Generic;
using Infrastructure.ADbContext;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DefaultConnection"];

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        //Register your services here
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOFwork>();
        
        return services;
    }
}