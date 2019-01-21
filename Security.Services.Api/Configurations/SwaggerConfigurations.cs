using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Security.Services.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Eventos.IO API",
                    Description = "API do site Eventos.IO",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Bertelli", Email = "diegobertelli.ti@gmail.com", Url = "http://teste.io" }
                });
            });
        }
    }
}
