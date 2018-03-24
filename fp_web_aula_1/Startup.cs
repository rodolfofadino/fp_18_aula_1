using fp_web_aula_1.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace fp_web_aula_1
{
    public class Startup 
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ILogerApi, LogerApi>();
            services.AddScoped<ILogerApi, LogerApi>();
            services.AddScoped<INoticiaService, NoticiaService>();

            //services.AddSingleton<ILogerApi, LogerApi>();

            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //app.Use(async (context, next) =>
            // {
            //     var a = 123;
            //     await next.Invoke();
            //     var b = 123;
            // });
            // app.Use(async (context, next) =>
            // {
            //     await next.Invoke();
            // });
            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync("Hello from 3nd delegate.");
            // });

            //if (env.IsDevelopment())
            //    app.UseDeveloperExceptionPage();

            // app.UseMiddleware<MeuMiddleware>();
            app.UseMeuMiddleware();
            app.UseMvc(r =>
            {
                //r.MapRoute(
                //name: "palestrantes",
                //template: "trilha/{nomedatrilha}",
                //defaults: new { controller = "Home", action = "listarpalestrantes" });


                r.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public class MeuMiddleware
    {
        private readonly ILogerApi _loggerApi;
        private readonly RequestDelegate _next;
        private Stopwatch inicio { get; set; }

        public MeuMiddleware(RequestDelegate next)
        {
            _loggerApi = new LogerApi();
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {

            inicio = Stopwatch.StartNew();// = DateTime.Now; 
            //logica do middleware
            await _next(httpContext);
            //login do fim do middleware aqui
            inicio.Stop();

            var final = inicio.ElapsedMilliseconds;// DateTime.Now.Subtract(inicio).TotalMilliseconds;
            _loggerApi.Log(httpContext, final);
        }

    }

    public class LogerApi : ILogerApi
    {
        private Guid guid;

        public LogerApi()
        {
            guid = Guid.NewGuid();
        }
        public void Log(HttpContext context, long totalTime)
        {
            //
        }
    }
    public interface ILogerApi
    {
        void Log(HttpContext context, long totalTime);
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMeuMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuMiddleware>();
        }

    }
}
