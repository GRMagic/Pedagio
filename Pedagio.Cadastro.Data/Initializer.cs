using Microsoft.Extensions.DependencyInjection;
using Pedagio.Cadastro.Application.Stores;
using System.Data;

namespace Pedagio.Cadastro.Data
{
    public static class Initializer
    {
        public static void AddCadastroData(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnection>(db => ConexaoBanco.Conectar(connectionString));
            services.AddScoped<IMarcaCommandStore, MarcaStore>();
            services.AddScoped<IMarcaQueryStore, MarcaStore>();
            services.AddScoped<IModeloCommandStore, ModeloStore>();
            services.AddScoped<IModeloQueryStore, ModeloStore>();
            services.AddScoped<ICarroCommandStore, CarroStore>();
            services.AddScoped<ICarroQueryStore, CarroStore>();
            services.AddScoped<IPassagemCommandStore, PassagemStore>();
            services.AddScoped<IPassagemQueryStore, PassagemStore>();
        }
    }
}
