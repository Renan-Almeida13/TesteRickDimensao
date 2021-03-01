using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dommel;
using Dapper.FluentMap.Dommel.Resolvers;
using TesteRickDimensao.Configuration;
using Microsoft.OpenApi.Models;
using Core.Contracts;
using Core.Core;
using Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace TesteRickDimensao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            DommelMapper.SetTableNameResolver(new DommelTableNameResolver());
            Configuration = configuration;
            StaticConfig = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfig { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRickCore, RickCore>();
            services.AddScoped<IUniversoCore, UniversoCore>();

            services.AddDbContext<RickDimensaoContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Universo Rick", Version = "v1" });
            });

            //Connection DB
            var connectionString = Configuration.GetConnectionString("UniversoRickDB");

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            })
                // Habilita a possibilidade de passar o Accept XML no Header (transforma retorno em XML)
                .AddXmlSerializerFormatters();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddTransient<CreateCoreConnectionsActionFilter>();
            services.AddMvc(options =>
            {
                options.Filters.AddService<CreateCoreConnectionsActionFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Universo Rick"));

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
