using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;

namespace DependencyInjection
{
    public class Startup
    {
        private IHostEnvironment env;

        public Startup(IHostEnvironment hostEnv) => env = hostEnv;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IRepository, MemoryRepository>();

            //TypeBroker.SetRepositoryType<AlternateRepository>();
            //services.AddTransient<IRepository, MemoryRepository>();
            services.AddTransient<IModelStorage, DictionaryStorage>();
            services.AddTransient<ProductTotalizer>();
            services.AddMvc().AddMvcOptions(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
