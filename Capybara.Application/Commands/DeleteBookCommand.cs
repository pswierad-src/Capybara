using Convey.CQRS.Commands;
using System;

namespace Capybara.Application.Commands
{
    public class DeleteBookCommand : ICommand
    {
        public Guid Id { get;}

        public DeleteBookCommand(Guid id)
        {
            Id = id;
        }
    }
}
