using ApiTienda.Data;
using ApiTienda.Helpers;
using ApiTienda.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApiTienda
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            String cadena = this.Configuration.GetConnectionString("awstienda");
            services.AddTransient<CypherService>();
            services.AddTransient<HelperToken>();
            services.AddTransient<RepositoryCategoria>();
            services.AddTransient<RepositoryCita>();
            services.AddTransient<RepositoryComentario>();
            services.AddTransient<RepositoryFactura>();
            services.AddTransient<RepositoryMaterial>();
            services.AddTransient<RepositoryTatuaje>();
            services.AddTransient<RepositoryTienda>();
            services.AddTransient<RepositoryUsuario>();
            services.AddDbContextPool<TiendaContext>(options =>
            options.UseMySql(cadena, ServerVersion.AutoDetect(cadena)));
            services.AddCors(options=>options.AddPolicy("AllowOrigin", c=>c.AllowAnyOrigin()));
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc(name: "v1", new OpenApiInfo
                    {
                        Title = "Api Tienda",
                        Version = "v1",
                        Description = "Api Tienda proyecto"
                    });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    //options.IncludeXmlComments(xmlPath);
                });
            HelperToken helper = new HelperToken(Configuration);
            services.AddAuthentication(helper.GetAuthOptions()).AddJwtBearer
                (helper.GetJwtBearerOptions());
            services.AddControllers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.AllowAnyOrigin());
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json", name: "Api v1");
                options.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
