using HR_Management.Application.contracts.persistence;
using HR_Management.Persistence.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR_Management.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region DB Context

        services.AddDbContext<LeaveManagementDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LeaveManagementConnectionString"));
        });

        #endregion

        #region IoC

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveTypeRepository));
        services.AddScoped(typeof(ILeaveAllocationRepository), typeof(LeaveAllocationRepository));

        #endregion

        return services;
    }
}