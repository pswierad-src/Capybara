using System;
using System.ComponentModel.DataAnnotations;

namespace Capybara.Application.Dto
{
    public class BookDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
