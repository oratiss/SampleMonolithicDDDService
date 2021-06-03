using ApplicationService.UserAccounting.Roles;
using AutoMapper;
using HSEWebApi.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence.Context;
using Persistence.Models.Roles;
using Persistence.Repositories.GenericRepositories;
using Persistence.UnitOfWorks;
using Utilities.BasedSetMappers;

namespace HSEWebApi
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
            //todo: to be amended with edited origins
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("SetOrigins",
            //        builder =>
            //        {
            //            builder.AllowAnyOrigin()
            //                .AllowAnyHeader()
            //                .AllowAnyMethod();
            //        });
            //});
            services.AddControllers();

            services.AddAuthentication("Bearer")
           .AddJwtBearer("Bearer", options =>
           {
               options.Authority = "https://localhost:5001";

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateAudience = false
               };
           });

            
            //So Important to be changed. maybe we do not have to do something which
            //does not require authentication
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "WebApi");
                });
            });

            services.AddSingleton<IAutoMapperConfiguration, AutoMapperConfiguration>();

            services.AddDbContext<IMelodiveMusicDbContext, MelodiveMusicDbContext>(options =>
            {
                options.UseSqlServer("name = ConnectionStrings:DefaultConnection");
            });

            services.AddUnitOfWork();
           

            services.AddScoped<IApplicationRoleService, ApplicationRoleService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Melodive Music Api", Version = "v1" });
            });

            //services.Configure<IISOptions>(options =>
            //{
            //    options.ForwardClientCertificate = false;
            //});

            var autoMapperConfiguration=new AutoMapperConfiguration();
            autoMapperConfiguration.Configure(services);

            var serviceProvider = services.BuildServiceProvider();
            var mapper = serviceProvider.GetService<IMapper>();

            
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
                c.SwaggerEndpoint("v1/swagger.json", "Melodive Music Api");
            });


            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
