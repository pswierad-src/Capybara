using System;

namespace Capybara.Application.Dto
{
    public class BookSimpleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
