using Capybara.Application.Dto;
using Capybara.Application.Queries;
using Capybara.Infrastructure.Context;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capybara.Infrastructure.Queries.Handlers
{
    public class GetBooksHandler : IQueryHandler<GetBooksQuery, IEnumerable<BookSimpleDto>>
    {
        private readonly ICapybaraContext context;

        public GetBooksHandler(ICapybaraContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<BookSimpleDto>> HandleAsync(GetBooksQuery query)
        {
            return await context.Books.Select(x => new BookSimpleDto
            {
                Id = x.Id,
                Title = x.Title,
            }).ToListAsync();
        }
    }
}
