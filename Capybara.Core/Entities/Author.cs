using System.Collections.Generic;

namespace Capybara.Core.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Update(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
