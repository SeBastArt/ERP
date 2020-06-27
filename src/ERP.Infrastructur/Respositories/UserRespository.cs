using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class UserRespository : IUserRespository
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserRespository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            // return await _signInManager.PasswordSignInAsync(email, password, false, false);
            SignInResult result = await _signInManager.PasswordSignInAsync(
                 email, password, false, false);
            return result;
        }

        public async Task<User> GetByEmailAsync(string requestEmail, CancellationToken cancellationToken = default)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Email == requestEmail, cancellationToken);
        }

        public async Task<IdentityResult> SignUpAsync(User user, string password, CancellationToken cancellationToken)
        {
            return await _userManager.CreateAsync(user, password);
        }
    }
}
