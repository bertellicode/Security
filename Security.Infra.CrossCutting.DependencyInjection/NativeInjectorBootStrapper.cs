using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Security.Infra.CrossCutting.JWT.Configurations;
using Security.Infra.CrossCutting.JWT.Interfaces;
using Security.Infra.CrossCutting.JWT.Models;

namespace Security.Infra.CrossCutting.DependencyInjection
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {


            //// Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUserProvider, UserProvider>();

            // Infra - JWT
            services.AddScoped<ICredentialsConfiguration, CredentialsConfiguration>();
            services.AddScoped<ITokenConfiguration, TokenConfiguration>();

            // Web
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
