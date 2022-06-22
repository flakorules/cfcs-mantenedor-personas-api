using AutoMapper;
using Cfcs.Mantenedor.API.Abstractions.Repository;
using Cfcs.Mantenedor.API.Model;
using Cfcs.Mantenedor.API.Profiles;
using Cfcs.Mantenedor.API.Repository;
using Cfcs.Mantenedor.API.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Cfcs.Mantenedor.API
{
    public class Startup
    {
        private readonly string MyCors = "MyCors";
        private readonly ConnectionStringUtility ConnectionStringUtility;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionStringUtility = new ConnectionStringUtility(Configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = ConnectionStringUtility.GetConnectionString();
            services.AddDbContext<MantenedorContext>(opts => opts.UseNpgsql(connectionString));         
            
            services.AddScoped<IPersonasRepository, PersonasRepository>();
            services.AddScoped<IRegionesRepository, RegionesRepository>();
            services.AddScoped<ICiudadesRepository, CiudadesRepository>();
            services.AddScoped<ISexoRepository, SexoRepository>();
            services.AddScoped<IComunasRepository, ComunasRepository>();
            services.AddScoped<ConnectionStringUtility>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cfcs.Mantenedor.API", Version = "v1" });
            });

            services.AddCors(options =>
            {

                options.AddPolicy(name: MyCors, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cfcs.Mantenedor.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(MyCors);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
