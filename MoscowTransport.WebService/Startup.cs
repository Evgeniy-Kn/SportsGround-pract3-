using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NameFacilities.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using NameFacilities.ApplicationServices.GetNameFacilityListUseCase;
using NameFacilities.ApplicationServices.Ports.Gateways.Database;
using NameFacilities.ApplicationServices.Repositories;
using NameFacilities.DomainObjects.Ports;

namespace NameFacilities.WebService
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
            services.AddDbContext<NameFacilityContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "NameFacilities.db")}")
            );

            services.AddScoped<INameFacilityDatabaseGateway, NameFacilityEFSqliteGateway>();

            services.AddScoped<DbNameFacilityRepository>();
            services.AddScoped<IReadOnlyNameFacilityRepository>(x => x.GetRequiredService<DbNameFacilityRepository>());
            services.AddScoped<INameFacilityRepository>(x => x.GetRequiredService<DbNameFacilityRepository>());

          

            services.AddScoped<IGetNameFacilityListUseCase, GetNameFacilityListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
