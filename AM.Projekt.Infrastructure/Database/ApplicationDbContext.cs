using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AM.Projekt.Domain.Entities;
using AM.Projekt.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AM.Projekt.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

 
        public DbSet<User> Users { get; set; }
    }

}