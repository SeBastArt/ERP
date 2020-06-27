using ERP.Domain.Extensions;
using ERP.Domain.Models;
using ERP.Domain.Requests.User;
using ERP.Domain.Responses.User;
using ERP.Domain.Respositories;
using ERP.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IUserRespository _userRespository;

        public UserService(IUserRespository userRespository, IOptions<AuthenticationSettings> authenticationSettings)
        {
            _userRespository = userRespository;
            _authenticationSettings = authenticationSettings.Value;
        }

        public async Task<UserResponse> GetUserAsync(GetUserRequest request, CancellationToken cancellationToken = default)
        {
            User response = await _userRespository.GetByEmailAsync(request.Email, cancellationToken);
            return (response != null) ?
            new UserResponse
            {
                LastName = response.LastName,
                FirstName = response.FirstName,
                Email = response.Email
            } : throw new StackException("user not found");
        }

        public async Task<TokenResponse> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default)
        {
            SignInResult signResult = await _userRespository.AuthenticateAsync(request.Email, request.Password, cancellationToken);

            if (!signResult.Succeeded)
            {
                throw new StackException("Wrong Passwort or Username");
            }

            User myUser = await _userRespository.GetByEmailAsync(request.Email);
            if (myUser == null)
            {
                throw new NotFoundException("user not found");
            }

            return new TokenResponse
            {
                Token = GenerateSecurityToken(request, myUser)
            };
        }

        public async Task<UserResponse> SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default)
        {
            User user = await _userRespository.GetByEmailAsync(request.Email, cancellationToken);
            if (user != null)
            {
                throw new StackException("User already exists");
            }

            user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                LastName = request.LastName,
                FirstName = request.FirstName
            };

            IdentityResult result = await _userRespository.SignUpAsync(user, request.Password, cancellationToken);
            if (!result.Succeeded)
            {
                StackException except = new StackException("Credentials not sufficient");
                foreach (IdentityError error in result.Errors)
                {
                    except.Errors.Add(error.Description);
                }
                throw except;
            }

            return new UserResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
        }

        private string GenerateSecurityToken(SignInRequest request, User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_authenticationSettings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                }),
                Expires = DateTime.UtcNow.AddDays(_authenticationSettings.ExpirationDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
