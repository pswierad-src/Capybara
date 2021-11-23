using Capybara.Api.Attributes;
using Capybara.Application;
using Capybara.Infrastructure;
using Convey;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Capybara.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args).Build().RunAsync();

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddControllers();

                services
                    .AddConvey()
                    .AddInfrastructure()
                    .AddApplication();

                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Capybara API",
                        Description = ""
                    });

                    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    string xmlFile2 = "Capybara.Application.xml";
                    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    string xmlPath2 = Path.Combine(AppContext.BaseDirectory, xmlFile2);
                    c.OperationFilter<BasicAuthOperationsFilter>();
                    c.IncludeXmlComments(xmlPath);
                    c.IncludeXmlComments(xmlPath2);
                });

                services.BuildServiceProvider();

            }).Configure(app =>
            {
                app
                .UseConvey()
                .UseInfrastructure()
                .UseRouting()
                .UseSwagger(c => { c.RouteTemplate = "swagger/{documentname}/swagger.json"; })
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = "swagger";
                })
                .UseEndpoints(e =>
                {
                    e.MapControllers();
                    e.Map("ping", async ctx => { await ctx.Response.WriteAsync("Alive"); });
                });
            });
        }
    }
}
