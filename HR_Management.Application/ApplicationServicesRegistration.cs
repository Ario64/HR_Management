using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace HR_Management.Application;

public static class ApplicationServicesRegistration
{
    public static void ConfigureApplicationServices(this IServiceCollection service)
    {
        //service.AddAutoMapper(typeof(MappingProfile));
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}