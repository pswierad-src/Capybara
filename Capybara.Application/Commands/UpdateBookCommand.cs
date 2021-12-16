using Convey.CQRS.Commands;
using System;

namespace Capybara.Application.Commands
{
    public class UpdateBookCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; }
        public decimal Price { get; }

        public UpdateBookCommand(Guid id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
    }
}
