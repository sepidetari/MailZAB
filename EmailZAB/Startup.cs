using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailZAB.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmailZAB
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IEmailRepository, MockEmailRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions {
                    SourceCodeLineCount = 5
                };
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }


            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                logger.LogInformation("MV1 : Incoming request");
                await context.Response.WriteAsync("Hello World!");
                await context.Response.WriteAsync(_config["Mykey"]);
            });
        }
    }
}
