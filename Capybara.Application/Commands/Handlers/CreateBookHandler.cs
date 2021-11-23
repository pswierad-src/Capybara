using Capybara.Application.Services.Repositories;
using Capybara.Core.Entities;
using Convey.CQRS.Commands;
using System.Threading.Tasks;

namespace Capybara.Application.Commands.Handlers
{
    public class CreateBookHandler : ICommandHandler<CreateBookCommand>
    {
        private readonly IBookRepository repository;

        public CreateBookHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task HandleAsync(CreateBookCommand command)
        {
            Book book = new Book(command.Title, command.Author, command.Price);

            await repository.AddAsync(book);
        }
    }
}
