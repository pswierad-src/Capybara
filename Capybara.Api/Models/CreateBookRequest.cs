using System.ComponentModel.DataAnnotations;

namespace Capybara.Api.Models
{
    public class CreateBookRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
