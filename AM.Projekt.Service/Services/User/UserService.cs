using System;
using System.Linq;
using AM.Projekt.Domain.Interfaces;

namespace AM.Projekt.Service.Services.User
{
    public interface IUserService
    {
        Domain.Entities.ApplicationUser Get(Guid id);
    }
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UserService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Domain.Entities.ApplicationUser Get(Guid id)
        {
            _applicationDbContext.ApplicationUsers.Add(new Domain.Entities.ApplicationUser()
            {
                Email = "a@a.pl",
                Id = new Guid(),
                Name = "test",
                Surname = "test"
            });
            _applicationDbContext.SaveChanges();
            return _applicationDbContext.ApplicationUsers.FirstOrDefault();
        }
    }
}