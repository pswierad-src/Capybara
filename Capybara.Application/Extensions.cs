using Convey;
using Convey.CQRS.Commands;

namespace Capybara.Application
{
    public static class Extensions
    {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder)
        {
            return builder
                .AddCommandHandlers()
                .AddInMemoryCommandDispatcher();
        }
    }
}
