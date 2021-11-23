using Capybara.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Capybara.Infrastructure.Context
{
    public interface ICapybaraContext
    {
        DbSet<Book> Books { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
