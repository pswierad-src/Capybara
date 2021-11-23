using Capybara.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Capybara.Application.Services.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetAsync(Guid id);
        Task AddAsync(Book entity);
        Task UpdateAsync(Book entity);
        Task DeleteAsync(Book entity);
    }
}
