using Jcf.WhereToPark.Api.Applications.User.Entities;

namespace Jcf.WhereToPark.Api.Core.Services.IServices
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string userName, string password);
    }
}
