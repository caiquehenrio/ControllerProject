using ControllerProject.DataBase;
using ControllerProject.Helpers;
using ControllerProject.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject
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
          
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer().AddDbContext<DataContext>(obj => obj.UseSqlServer(Configuration.GetConnectionString("DataBase")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<Helpers.ISession, Session>();
            services.AddScoped<Helpers.IEmail, Email>();
            services.AddSession(o =>
           {
             
               o.Cookie.HttpOnly = true;
               o.Cookie.IsEssential = true;
             
           });
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            if (env.IsDevelopment())
            {
              
                app.UseDeveloperExceptionPage();
              
            }
            else
            {
              
                app.UseExceptionHandler("/Home/Error");
              
            }
          
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
              
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
              
            });
          
        }
      
    }
  
}
