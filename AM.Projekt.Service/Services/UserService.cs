using System;
using System.Linq;
using AM.Projekt.Domain.Entities;
using AM.Projekt.Domain.Interfaces;

namespace AM.Projekt.Service.Services
{
    public interface IUserService
    {
        User Get(Guid id);
    }
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UserService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public User Get(Guid id)
        {
            _applicationDbContext.Users.Add(new User()
            {
                Email = "a@a.pl",
                Id = new Guid(),
                Name = "test",
                Surname = "test"
            });
            _applicationDbContext.SaveChanges();
            return _applicationDbContext.Users.FirstOrDefault();
        }
    }
}