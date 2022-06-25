using BlazorAppAuthTest.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BlazorAppAuthTest.DAL.Repository
{
    public class LiteDbRoleRepository : IRoleRepository
    {
        private readonly ILiteDbRepository _dbRepo;

        public LiteDbRoleRepository(ILiteDbRepository dbRepo)
        {
            _dbRepo = dbRepo;
        }

        public async Task AddSuperAdmin(IdentityUser user)
        {
            IdentityRole[]? allRoles = _dbRepo.IdentityRoles.Query().ToArray();

            //TODO check if everything fine, otherwise return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });

            foreach (var role in allRoles)
            {
                var newRoleUserPair = new RolesForUsers()
                {
                    IdentityRole = role,
                    IdentityUser = user
                };
                _dbRepo.RolesForUsers.Insert(newRoleUserPair);
            }
        }

        public async Task AddUserAsync(IdentityUser user)
        {
            IdentityRole? userRole = await FindByNameAsync(UserRoles.user);

            //TODO check if everything fine, otherwise return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });

            var newRoleUserPair = new RolesForUsers()
            {
                IdentityRole = userRole,
                IdentityUser = user
            };
            _dbRepo.RolesForUsers.Insert(newRoleUserPair);
        }

        public async Task<IdentityRole> FindByNameAsync(UserRoles role)
        {
            IdentityRole? res = _dbRepo.IdentityRoles.Query().Where(u => u.Name == role.ToString()).FirstOrDefault();

            //TODO check if everything fine, otherwise return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });

            return res;
        }

        public async Task<IdentityRole[]> GetRolesAsync(IdentityUser user)
        {
            RolesForUsers[]? rolesForUser = _dbRepo.RolesForUsers.Query().Where(u => u.IdentityUser.Id == user.Id)
                .Include(u => u.IdentityRole)
                .ToArray();

            //TODO check if everything fine, otherwise return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });

            return rolesForUser.Select(rfu => rfu.IdentityRole).ToArray();
        }
    }
}
