using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });

            services.AddMvc().AddMvcOptions(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}");

                routes.Routes.Add(new LegacyRoute(
                    "/articles/Windows_3.1_Overview.html",
                    "/old/.NET_1.0_Class_Library"));

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "out",
                    template: "outbound/{controller=Home}/{action=Index}");

                //routes.MapRoute("otro","{controller}/{action}",new { myVar = "true" });

                //routes.MapRoute(
                //    name: "NewRoute",
                //    template: "App/Do{action}",
                //    defaults: new { controller = "Home" });
            });

            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "MyRoute",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "Home", action = "Index" },
            //        constraints: new { id = new WeekDayConstraint() });

                //routes.MapRoute(
                //    name: "MyRoute",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" },
                //    constraints: new { id = new IntRouteConstraint() });


                //routes.MapRoute(
                //    name: "MyRoute",
                //    //template: "{controller=Home}/{action=Index}/{id=DefaultId}");
                //    //template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");
                //    template: "{controller=Home}/{action=Index}/{id:int?}");


            //routes.MapRoute(
            //    name: "ShopSchema2",
            //    template: "Shop/OldAction",
            //    defaults: new { controller = "Home", action = "Index" });

            //routes.MapRoute(
            //    name: "ShopScheme",
            //    template: "Shop/{action}",
            //    defaults: new { controller = "Home"}
            //);

            //routes.MapRoute("", "X{controller}/{action}");

            //routes.MapRoute(
            //    name: "default",
            //    template: "{controller=Home}/{action=Index}"
            //);

            //routes.MapRoute(
            //    name: "",
            //    template: "Public/{controller=Home}/{action=Index}"
            //);
        //});

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
