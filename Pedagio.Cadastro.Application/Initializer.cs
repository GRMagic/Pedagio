using Microsoft.Extensions.DependencyInjection;
using Pedagio.Cadastro.Application.Queries;
using Pedagio.Cadastro.Application.Services;

namespace Pedagio.Cadastro.Application
{
    public static class Initializer
    {
        public static void AddCadastroQueries(this IServiceCollection services)
        {
            services.AddScoped<IMarcaQuery, MarcaQuery>();
            services.AddScoped<IModeloQuery, ModeloQuery>();
            services.AddScoped<ICarroQuery, CarroQuery>();
            services.AddScoped<IPassagemQuery, PassagemQuery>();
        }

        public static void AddCadastroServices(this IServiceCollection services)
        {
            services.AddScoped<IPassagemService, PassagemService>();
        }
    }
}
