using Capybara.Application.Dto;
using Capybara.Application.Exceptions;
using Capybara.Application.Queries;
using Capybara.Core.Entities;
using Capybara.Infrastructure.Context;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Capybara.Infrastructure.Queries.Handlers
{
    public class GetBookHandler : IQueryHandler<GetBookQuery, BookDto>
    {
        private readonly ICapybaraContext context;

        public GetBookHandler(ICapybaraContext context)
        {
            this.context = context;
        }

        public async Task<BookDto> HandleAsync(GetBookQuery query)
        {
            Book book = await context.Books.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (book is null)
            {
                throw new EntityNotFoundInDatabaseException();
            }

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                CreatedAt = book.DateCreated,
                ModifiedAt = book.DateModified
            };
        }
    }
}
