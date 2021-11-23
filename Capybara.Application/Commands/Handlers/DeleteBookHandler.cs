using Capybara.Application.Exceptions;
using Capybara.Application.Services.Repositories;
using Capybara.Core.Entities;
using Convey.CQRS.Commands;
using System.Threading.Tasks;

namespace Capybara.Application.Commands.Handlers
{
    public class DeleteBookHandler : ICommandHandler<DeleteBookCommand>
    {
        private readonly IBookRepository repository;

        public DeleteBookHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task HandleAsync(DeleteBookCommand command)
        {
            Book book = await repository.GetAsync(command.Id);

            if (book is null)
            {
                throw new EntityNotFoundInDatabaseException();
            }

            await repository.DeleteAsync(book);
        }
    }
}
