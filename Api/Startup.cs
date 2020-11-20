using Application.Repositories;
using Application.Services.Activity;
using Application.Services.Category;
using Application.Services.Training;
using Application.Services.TrainingDate;
using Application.Services.User;
using Infrastructure.SqlServer.Activity;
using Infrastructure.SqlServer.Category;
using Infrastructure.SqlServer.Training;
using Infrastructure.SqlServer.TrainingDate;
using Infrastructure.SqlServer.Unit;
using Infrastructure.SqlServer.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FitnessBattle
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                    });
            });

            //services
            services.AddSingleton<IActivityService, ActivityService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ITrainingService, TrainingService>();
            services.AddSingleton<ITrainingDateService, TrainingDateService>();
            services.AddSingleton<IUnitService, UnitService>();
            services.AddSingleton<IUserService, UserService>();
            
            //repositories
            services.AddSingleton<IActivityRepository, ActivityRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ITrainingDateRepository, TrainingDateRepository>();
            services.AddSingleton<ITrainingRepository, TrainingRepository>();
            services.AddSingleton<IUnitRepository, UnitRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            if (env.IsProduction())
            {
                app.UseHttpsRedirection();
            }
            
            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}