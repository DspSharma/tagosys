using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagosysWeb.Core.Mapping;
using TagosysWeb.Data.DBContext;
using TagosysWeb.Data.UnitOfWork;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<tagosyswebContext>(
            Options =>
            {
                Options.UseMySql(Configuration.GetConnectionString("tagosysWebDB"),
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserService, UserService>();
            // services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IImageKitService, ImageKitService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ISystemSettingService, SystemSettingService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IPostService,PostService>();
            services.AddScoped<IPostDescriptionService, PostDescriptionService>();

            services.AddAutoMapper(typeof(MappingProfile));


            services.AddDistributedMemoryCache();
            services.AddSession(Options =>
            {
                Options.IdleTimeout = TimeSpan.FromHours(24);
            });


            services.AddControllersWithViews();

            services.AddControllers();

            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TagosysWeb", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TagosysWeb v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                name: "Admin",
                pattern: "Admin/{controller=Auth}/{action=Login}/{id?}",
                defaults: new { area = "Admin" }
            );
                endpoints.MapAreaControllerRoute(
                                  name: "default",
                                  areaName: "Public",
                                  defaults: new { area = "Public" },
                                  pattern: "{area}/{controller=Home}/{action=index}/{id?}"
                );

                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }


    }
}
