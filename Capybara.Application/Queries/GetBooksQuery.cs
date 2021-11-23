using Capybara.Application.Dto;
using Convey.CQRS.Queries;
using System.Collections.Generic;

namespace Capybara.Application.Queries
{
    public class GetBooksQuery : IQuery<IEnumerable<BookSimpleDto>>
    {
    }
}
