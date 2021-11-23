using Capybara.Application.Dto;
using Convey.CQRS.Queries;
using System;

namespace Capybara.Application.Queries
{
    public class GetBookQuery : IQuery<BookDto>
    {
        public Guid Id { get;}

        public GetBookQuery(Guid id)
        {
            Id = id;
        }
    }
}
