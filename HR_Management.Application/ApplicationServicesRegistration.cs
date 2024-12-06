using System.Reflection;
using HR_Management.Application.profiles;
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