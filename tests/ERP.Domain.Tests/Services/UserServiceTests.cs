using ERP.Domain.Extensions;
using ERP.Domain.Requests.User;
using ERP.Domain.Responses.User;
using ERP.Domain.Services;
using ERP.Domain.Settings;
using ERP.Fixtures;
using Microsoft.Extensions.Options;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace ERP.Domain.Tests.Services
{
    public class UserServiceTests : IClassFixture<UsersContextFactory>
    {
        private readonly IUserService _userService;

        public UserServiceTests(UsersContextFactory usersContextFactory)
        {
            _userService = new UserService(usersContextFactory.InMemoryUserManager,
                Options.Create(
                    new AuthenticationSettings
                    {
                        Secret = "Very Secret key-word to match",
                        ExpirationDays = 7
                    }
                )
            );
        }

        [Fact]
        public async Task Signin_with_invalid_user_should_return_a_valid_token_response()
        {
            SignInRequest request = new SignInRequest { Email = "invalid.user", Password = "invalid_password" };
            await Task.Run(() => _userService.SignInAsync(request).ShouldThrow<StackException>());
        }

        [Fact]
        public async Task Signin_with_valid_user_should_return_a_valid_token_response()
        {
            TokenResponse result =
                await _userService.SignInAsync(new SignInRequest { Email = "samuele.resca@example.com", Password = "P@$$w0rd" });
            result.Token.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task Signup_should_create_a_new_user()
        {
            string newEmail = "samuele.resca.newaccount@example.com";
            string firstName = "Samuele";
            string lastName = "Resca";

            UserResponse result =
                await _userService.SignUpAsync(new SignUpRequest
                { LastName = lastName, FirstName = firstName, Email = newEmail, Password = "P@$$w0rd" });

            result.FirstName.ShouldBe(firstName);
            result.Email.ShouldBe(newEmail);
        }
    }
}
