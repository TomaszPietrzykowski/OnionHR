using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionHR.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using OnionHR.Persistence.Repositories;
using OnionHR.Application.Contracts.Persistance;

namespace OnionHR.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HrDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();


        return services;
    }
}
