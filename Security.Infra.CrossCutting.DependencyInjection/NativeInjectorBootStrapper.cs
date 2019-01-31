using Microsoft.Extensions.DependencyInjection;
using Security.Infra.CrossCutting.Identity.Interfaces;
using Security.Infra.CrossCutting.Identity.Models;
using Security.Infra.CrossCutting.Identity.Services;
using Security.Infra.CrossCutting.JWT.Configurations;
using Security.Infra.CrossCutting.JWT.Interfaces;

namespace Security.Infra.CrossCutting.DependencyInjection
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //// Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUser, AspNetUser>();

            // Infra - JWT
            services.AddScoped<ICredentialsConfiguration, CredentialsConfiguration>();
            services.AddScoped<ITokenConfiguration, TokenConfiguration>();
        }
    }
}
