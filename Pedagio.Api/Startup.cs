using System;
using System.Data;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pedagio.Cadastro.Data;
using MediatR;
using Pedagio.Cadastro.Application.Handlers.Marca;
using Pedagio.Cadastro.Application.Queries;
using Pedagio.Cadastro.Application.Services;
using Pedagio.Cadastro.Application.Utils;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Globalization;

namespace Pedagio.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDbConnection>(db => ConexaoBanco.Conectar(Configuration.GetConnectionString("AppConnectionString")));
            services.AddScoped<IMarcaStore, MarcaStore>();
            services.AddScoped<IModeloStore, ModeloStore>();
            services.AddScoped<ICarroStore, CarroStore>();
            services.AddScoped<IPassagemStore, PassagemStore>();
            services.AddScoped<IMarcaQuery, MarcaQuery>();
            services.AddScoped<IModeloQuery, ModeloQuery>();
            services.AddScoped<ICarroQuery, CarroQuery>();
            services.AddScoped<IPassagemQuery, PassagemQuery>();
            services.AddScoped<IPassagemService, PassagemService>();
            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml"));
                c.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, $"{typeof(BusinessException).Assembly?.GetName().Name}.xml"));
            });
            services.AddMediatR(typeof(Startup), typeof(BusinessException));

            AssemblyScanner.FindValidatorsInAssembly(typeof(BusinessException).Assembly)
                .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));

            services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, ProduceResponseTypeModelProvider>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de ped�gio");
                c.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
