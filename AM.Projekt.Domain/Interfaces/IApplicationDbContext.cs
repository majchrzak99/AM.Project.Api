using System.Threading;
using System.Threading.Tasks;
using AM.Projekt.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AM.Projekt.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}