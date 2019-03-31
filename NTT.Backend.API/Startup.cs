using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NTT.Backend.API.Contexto;
using NTT.Backend.API.Services;

namespace NTT.Backend.API
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
            // autenticacion
            // autorizacion
            // cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
            // signalr
            // base
            services.AddDbContext<VentasContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("cnnVentas"));
            });
            // id
            // services.AddTransient<IArticuloServices, ArticuloServicesMemoria>();
            services.AddTransient<IArticuloServices, ArticuloServicesSQL>();
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<ITipoUsuarioServices, TipoUsuarioServices>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
