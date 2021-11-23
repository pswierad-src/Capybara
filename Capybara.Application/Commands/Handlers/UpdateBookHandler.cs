using Capybara.Application.Exceptions;
using Capybara.Application.Services.Repositories;
using Capybara.Core.Entities;
using Convey.CQRS.Commands;
using System.Threading.Tasks;

namespace Capybara.Application.Commands.Handlers
{
    public class UpdateBookHandler : ICommandHandler<UpdateBookCommand>
    {
        private readonly IBookRepository repository;

        public UpdateBookHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task HandleAsync(UpdateBookCommand command)
        {
            Book book = await repository.GetAsync(command.Id);

            if (book is null)
            {
                throw new EntityNotFoundInDatabaseException();
            }

            book.Update(command.Title, command.Author, command.Price);

            await repository.UpdateAsync(book);
        }
    }
}
