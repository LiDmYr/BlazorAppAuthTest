using Microsoft.AspNetCore.Identity;

namespace BlazorAppAuthTest.DAL.Repository
{
    //TODO Fix async methods without async code inside
    public class LiteDbUserRepository : IDisposable, IUserRepository
    {
        private readonly ILiteDbRepository _dbRepo;
        private readonly IRoleRepository _roleRepository;

        public LiteDbUserRepository(ILiteDbRepository dbRepo, IRoleRepository roleRepository)
        {
            _dbRepo = dbRepo;
            this._roleRepository = roleRepository;
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user)
        {
            LiteDB.BsonValue? res = _dbRepo.IdentityUsers.Insert(user);

            await _roleRepository.AddUserAsync(user);

            //TODO check if everything fine, otherwise return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(IdentityUser user)
        {
            LiteDB.BsonValue? res = _dbRepo.IdentityUsers.Delete(user.Id);

            //TODO check if everything fine, otherwise return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });

            return IdentityResult.Success;
        }

        public async Task<IdentityUser> FindByIdAsync(string userId)
        {
            IdentityUser? res = _dbRepo.IdentityUsers.Query().Where(u => u.Id == userId).FirstOrDefault();

            //TODO check if everything fine, otherwise return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });

            return res;
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            IdentityUser? res = _dbRepo.IdentityUsers.Query().Where(u => u.UserName == userName).FirstOrDefault();

            //TODO check if everything fine, otherwise return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });

            return res;
        }

        public void Dispose()
        {
            //TODO Dispose Conntection
        }

        public async Task<IdentityUser> FindByEmailAsync(string normalizedEmail)
        {
            IdentityUser? res = _dbRepo.IdentityUsers.Query().Where(u => u.NormalizedEmail == normalizedEmail || u.Email == normalizedEmail).FirstOrDefault();

            //TODO check if everything fine, otherwise return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });

            return res;
        }
    }
}
