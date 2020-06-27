using ERP.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IUserRespository
    {
        Task<SignInResult> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default);
        Task<IdentityResult> SignUpAsync(User user, string password, CancellationToken cancellationToken = default);
        Task<User> GetByEmailAsync(string requestEmail, CancellationToken cancellationToken = default);
    }
}
