using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using AppEnviosREST.Data;
namespace AppEnviosREST
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
            services.AddMvc();
            //ASUS-JUVENTINO\SQLEXPRESS;Initial Catalog=DB_COCACOLA_NAY; MultipleActiveResultSets=true; User ID=sa;Password=sqlserver123
            services.AddDbContext<FicDBContext>(options =>
                //options.UseSqlServer(Configuration.GetConnectionString("AppWebSrvContext")));
                options.UseSqlServer(Configuration.GetConnectionString(
                    "AppWebSrvContext"
                    )));
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
                app.UseExceptionHandler("Home/Error");
            }

            //app.UseHttpsRedirection();
            //app.UseMvc();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=FicIndex}/{action=Index}");
            });
        }
    }
}

