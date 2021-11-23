using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Capybara.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IQueryDispatcher queryDispatcher;
        protected readonly ICommandDispatcher commandDispatcher;

        public BaseController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }
    }
}
