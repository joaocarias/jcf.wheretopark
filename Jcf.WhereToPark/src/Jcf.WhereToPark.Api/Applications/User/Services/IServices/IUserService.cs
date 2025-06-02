namespace Jcf.WhereToPark.Api.Application.User.Services.IServices
{
    public interface IUserService
    {
        Task<Entities.User?> GetAsync(Guid id);
        Task<Entities.User?> CreateAsync(Entities.User user);
    }
}
