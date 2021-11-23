using Convey.CQRS.Commands;
using System;

namespace Capybara.Application.Commands
{
    public class UpdateBookCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; }
        public string Author { get; }
        public decimal Price { get; }

        public UpdateBookCommand(Guid id, string title, string author, decimal price)
        {
            Id = id;
            Title = title;
            Author = author;
            Price = price;
        }
    }
}
