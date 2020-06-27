using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ERP.Fixtures
{
    public class UsersContextFactory
    {
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IList<User> _users;

        public UsersContextFactory()
        {
            _passwordHasher = new PasswordHasher<User>();

            _users = new List<User>();

            User user = new User
            {
                Id = "test_id",
                Email = "samuele.resca@example.com",
                FirstName = "Samuele",
                LastName = "Resca"
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, "P@$$w0rd");

            _users.Add(user);
        }

        public IUserRespository InMemoryUserManager => GetInMemoryUserManager();

        private IUserRespository GetInMemoryUserManager()
        {
            Mock<IUserRespository> fakeUserService = new Mock<IUserRespository>();

            fakeUserService.Setup(x => x.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync((string email, string password, CancellationToken token) =>
                {
                    User user = _users.FirstOrDefault(x => x.Email == email);

                    if (user == null)
                    {
                        return SignInResult.Failed;
                    }

                    PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
                    return (result == PasswordVerificationResult.Success) ? SignInResult.Success : SignInResult.Failed;
                });

            fakeUserService.Setup(x => x.GetByEmailAsync(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync((string email, CancellationToken token) => _users.FirstOrDefault(x => x.Email == email));

            fakeUserService.Setup(x => x.SignUpAsync(It.IsAny<User>(), It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync((User user, string password, CancellationToken token) =>
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                    _users.Add(user);

                    return IdentityResult.Success;
                });

            return fakeUserService.Object;
        }
    }
}
