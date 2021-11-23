using Capybara.Application.Services.Repositories;
using Capybara.Core.Entities;
using Capybara.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Capybara.Infrastructure.Services.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ICapybaraContext context;

        public BookRepository(ICapybaraContext context)
        {
            this.context = context;
        }

        public async Task<Book> GetAsync(Guid id)
        {
            return await context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Book entity)
        {
            await context.Books.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book entity)
        {
            context.Books.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book entity)
        {
            context.Books.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
