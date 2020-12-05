using System.Text;
using Application.Repositories;
using Application.Services.Activity;
using Application.Services.Auth;
using Application.Services.Category;
using Application.Services.Training;
using Application.Services.TrainingDate;
using Application.Services.Unit;
using Application.Services.User;
using FitnessBattle.TokenManager;
using Infrastructure.SqlServer.Activity;
using Infrastructure.SqlServer.Category;
using Infrastructure.SqlServer.Training;
using Infrastructure.SqlServer.TrainingDate;
using Infrastructure.SqlServer.Unit;
using Infrastructure.SqlServer.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

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

            //pwt authentification

            var key = Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]);

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    //on règle les options pour JwtBearer
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidIssuers = new string[] { Configuration["Jwt:Issuer"] },
                        ValidAudiences = new string[] { Configuration["Jwt:Issuer"] },
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true
                    };
                });
            //tools
            services.AddSingleton<ITokenManager, Application.Services.TokenManager.TokenManager>();
                        
            //services
            services.AddSingleton<IActivityService, ActivityService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ITrainingService, TrainingService>();
            services.AddSingleton<ITrainingDateService, TrainingDateService>();
            services.AddSingleton<IUnitService, UnitService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAuthService, AuthService>();
            
            
            
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}