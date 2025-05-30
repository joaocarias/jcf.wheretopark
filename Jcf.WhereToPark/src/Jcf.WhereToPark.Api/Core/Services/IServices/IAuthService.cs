using Jcf.WhereToPark.Api.Application.User.Entities;

namespace Jcf.WhereToPark.Api.Core.Services.IServices
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string userName, string password);
    }
}
