using Microsoft.Extensions.DependencyInjection;
using Security.Infra.CrossCutting.DependencyInjection;

namespace Security.Services.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
