using Convey.CQRS.Commands;

namespace Capybara.Application.Commands
{
    public class CreateBookCommand : ICommand
    {
        public string Title { get;}
        public string Author { get;}
        public decimal Price { get; }

        public CreateBookCommand(string title, string author, decimal price)
        {
            Title = title;
            Author = author;
            Price = price;
        }
    }
}
