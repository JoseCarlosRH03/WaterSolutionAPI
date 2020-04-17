using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WaterSolutionAPI.Interfaces;
using WaterSolutionAPI.ModelDTO;
using WaterSolutionAPI.Models;
using WaterSolutionAPI.Servicios;
using WaterSolutionAPI.WaterSolutionDBC;
namespace WaterSolutionAPI
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
            services.AddAutoMapper(configuration => 
            {
                configuration.CreateMap<Solicitud, SolicitudDTO>();
                configuration.CreateMap<Empleados, EmpleadoDTO2>();
                configuration.CreateMap<Departamentos, DepartamentoDTO>();
                configuration.CreateMap<Secciones, SeccionDTO>();
                configuration.CreateMap<Cotizaciones, CotizacionesDTO>();
                configuration.CreateMap<DetalleCotizacion, DetalleCotizacionDTO>();
                configuration.CreateMap<Material, MaterialDTO>();
                configuration.CreateMap<RutaSolicitud, RutaSolicitudDTO>();
                configuration.CreateMap<Ruta, RutaDTO>();

            }, typeof(Startup));
            services.AddCors();

            services.AddDbContext<WaterSolutionDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped<IEmpleados, EmpleadoServices>();
            services.AddScoped<ICliente, ClienteService>();
            services.AddScoped<ICargo, CargoServices>();
            services.AddScoped<ICotizaciones, CotizacioneServices>();
            services.AddScoped<IDepartamento, DepartamentoServices>();
            services.AddScoped<IDetalleCotizacion, DetalleCotizacionService>();
            services.AddScoped<IMaterial, MaterialServices>();
            services.AddScoped<IRole, RoleServices>();
            services.AddScoped<IPermisoRole, PermisoRoleServices>();
            services.AddScoped<IRuta, RutaServices>();
            services.AddScoped<ISecciones, SeccioneServices>();
            services.AddScoped<ISolicitud, SolicitudServices>();
            services.AddScoped<IUsuario, UsuarioServices>();

            services.AddControllers().AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);  

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
