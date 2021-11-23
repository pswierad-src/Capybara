using System;

namespace Capybara.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, decimal price)
        {
            Title = title;
            Author = author;
            Price = price;
            DateCreated = DateTime.UtcNow;
        }

        public void Update(string title, string author, decimal price)
        {
            Title = title;
            Author = author;
            Price = price;
            DateModified = DateTime.UtcNow;
        }
    }
}
