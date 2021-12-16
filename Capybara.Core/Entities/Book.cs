using System;
using System.Collections.Generic;

namespace Capybara.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public Book(string title, decimal price)
        {
            Title = title;
            Price = price;
            DateCreated = DateTime.UtcNow;
        }

        public void Update(string title, decimal price)
        {
            Title = title;
            Price = price;
            DateModified = DateTime.UtcNow;
        }
    }
}
