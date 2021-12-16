using Convey.CQRS.Commands;

namespace Capybara.Application.Commands
{
    public class CreateBookCommand : ICommand
    {
        public string Title { get;}
        public decimal Price { get; }

        public CreateBookCommand(string title, decimal price)
        {
            Title = title;
            Price = price;
        }
    }
}
