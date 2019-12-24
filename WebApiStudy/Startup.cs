using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using WebApiStudy.Data;
using WebApiStudy.Data.Repository;
using WebApiStudy.Data.Repository.EntityRepository.BidRepo;
using WebApiStudy.Data.Repository.EntityRepository.UserRepo;
using WebApiStudy.Middleware;
using WebApiStudy.Service.UserServices;

namespace WebApiStudy
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
            services.AddAutoMapper(typeof(MappingProfiles.MappingProfiles));
            services.AddSwaggerGen(SetupSwaggerGen);
            string connectionString = Configuration.GetConnectionString("dbConnectionString");
            services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBidRepository, BidRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            //services.AddControllers().AddJsonOptions(configure=>configure.JsonSerializerOptions.)
            //services.AddMvc().AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(SetupSwaggerUI);

            app.UseRouting();
            app.UseAuthorization();

            app.UseErrorHandlnig();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #region
        private void SetupSwaggerGen(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions options)
        {
            var info = new OpenApiInfo { Title = "My API", Version = "v1" };
            options.SwaggerDoc("v1", info);
        }

        private void SetupSwaggerUI(Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIOptions options)
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        }
        #endregion
    }
}
