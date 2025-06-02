namespace Jcf.WhereToPark.Api.Applications.User.Services.IServices
{
    public interface IUserService
    {
        Task<Entities.User?> GetAsync(Guid id);
        Task<IEnumerable<Entities.User>?> GetAllAsync();
        Task<Entities.User?> CreateAsync(Entities.User user);
    }
}
