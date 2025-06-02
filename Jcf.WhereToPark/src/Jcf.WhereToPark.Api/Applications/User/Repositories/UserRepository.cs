using Dapper;
using Jcf.WhereToPark.Api.Applications.User.Queries;
using Jcf.WhereToPark.Api.Applications.User.Repositories.IRepositories;
using Jcf.WhereToPark.Api.Applications.User.Services;
using Jcf.WhereToPark.Api.Data.Contexts;

namespace Jcf.WhereToPark.Api.Applications.User.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly AppDapperContext _appDapperContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext appDbContext, AppDapperContext appDapperContext, ILogger<UserRepository> logger)
        {
            _appDbContext = appDbContext;
            _appDapperContext = appDapperContext;
            _logger = logger;
        }

        public async Task<Entities.User?> CreateAsync(Entities.User entity)
        {
            try
            {
                await _appDbContext.Users.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserService)} | {nameof(CreateAsync)} | Error: {ex.Message}");
                return null;
            }
        }

        public bool Delete(Entities.User entity)
        {
            try
            {
                entity.Delete();
                return Update(entity) is not null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserService)} | {nameof(Delete)} | Error: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<Entities.User>?> GetAllAsync()
        {
            try
            {
                var result = await _appDapperContext.Connection.QueryAsync<Entities.User>(UserQuery.GET_ALL, null, _appDapperContext.Transaction);
                return result ?? Enumerable.Empty<Entities.User>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserService)} | {nameof(GetAllAsync)} | Error: {ex.Message}");
                return Enumerable.Empty<Entities.User>();
            }
        }

        public async Task<Entities.User?> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _appDapperContext.Connection.QueryFirstOrDefaultAsync<Entities.User>(
                   UserQuery.GET,
                   new { Id = id },
                   _appDapperContext.Transaction
               );
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserService)} | {nameof(GetByIdAsync)} | Error: {ex.Message}");
                return null;
            }
        }

        public Entities.User? Update(Entities.User entity)
        {
            try
            {
                _appDbContext.Users.Update(entity);
                _appDbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{nameof(UserRepository)} - {nameof(Update)}] | {ex.Message}");
                return null;
            }
        }
    }
}
