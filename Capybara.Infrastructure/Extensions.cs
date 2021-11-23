using Capybara.Application.Services.Repositories;
using Capybara.Infrastructure.Context;
using Capybara.Infrastructure.Services.Repositories;
using Convey;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Capybara.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            IConfiguration configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();

            builder
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher();

            IServiceCollection services = builder.Services;

            string capybaraString = configuration.GetConnectionString("Capybara");
            services.AddDbContext<CapybaraContext>(options => options.UseSqlServer(capybaraString));
            services.AddScoped<ICapybaraContext, CapybaraContext>();

            services.AddTransient<IBookRepository, BookRepository>();

            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseConvey();

            return app;
        }
    }
}
