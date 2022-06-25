using BlazorAppAuthTest.DAL.Repository;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BlazorAppAuthTest.CustomAuntAuth
{
    public partial class LiteDbUserStore : IUserClaimStore<IdentityUser> // needed to provide base for roles. can be used for policies also
    {
        public async Task<IList<Claim>> GetClaimsAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            return new List<Claim>(); // we do not use claims, but it's called during identifying roles
        }

        public Task AddClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceClaimAsync(IdentityUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IdentityUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public partial class LiteDbUserStore :
        IUserRoleStore<IdentityUser>, // needed to match roles and users
        IUserEmailStore<IdentityUser>, // needed to build auntefication on emails
        IUserPasswordStore<IdentityUser> // needed to use passwords
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public LiteDbUserStore(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return await _userRepository.CreateAsync(user);
        }

        public async Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return await _userRepository.DeleteAsync(user);
        }

        public async Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userId == null) throw new ArgumentNullException(nameof(userId));
            //TODO Parse if not string
            //if (!Guid.TryParse(userId, out string idGuid))
            //{
            //    throw new ArgumentException("Not a valid Guid id", nameof(userId));
            //}

            return await _userRepository.FindByIdAsync(userId);
        }

        public async Task<IdentityUser> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userName == null) throw new ArgumentNullException(nameof(userName));

            return await _userRepository.FindByNameAsync(userName);
        }

        public async Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return user.NormalizedUserName;
        }

        public async Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return user.Id;
        }

        public async Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return user.UserName;
        }

        public async Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (normalizedName == null) throw new ArgumentNullException(nameof(normalizedName));

            user.NormalizedUserName = normalizedName;
        }

        public async Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (userName == null) throw new ArgumentNullException(nameof(userName));

            user.UserName = userName;
        }

        public async Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            //TODO
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //TODO Implement
        }

        public async Task SetEmailAsync(IdentityUser user, string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (email == null) throw new ArgumentNullException(nameof(email));

            user.Email = email;
        }

        public async Task<string> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return user.Email;
        }

        public async Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return user.EmailConfirmed;
        }

        public async Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            user.EmailConfirmed = confirmed;
        }

        public async Task<IdentityUser> FindByEmailAsync(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (email == null) throw new ArgumentNullException(nameof(email));
            //if (!Guid.TryParse(userId, out string idGuid))
            //{
            //    throw new ArgumentException("Not a valid Guid id", nameof(userId));
            //}

            return await _userRepository.FindByEmailAsync(email);
        }

        public async Task<string> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return user.NormalizedEmail;
        }

        public async Task SetNormalizedEmailAsync(IdentityUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (normalizedEmail == null) throw new ArgumentNullException(nameof(normalizedEmail));

            user.NormalizedEmail = normalizedEmail;
        }

        public async Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (passwordHash == null) throw new ArgumentNullException(nameof(passwordHash));

            user.PasswordHash = passwordHash;
        }

        public async Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return user.PasswordHash;
        }

        public async Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException(nameof(user));

            return !string.IsNullOrWhiteSpace(user.PasswordHash);
        }

        public Task AddToRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetRolesAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            const string superUserName = "liashkod@gmail.com";

            if (user.UserName == superUserName)
            {
                //TODO kind of initialization
                IdentityRole[] superAdminRoles = await _roleRepository.GetRolesAsync(user);
                if (superAdminRoles.Length == 0)
                {
                    await _roleRepository.AddSuperAdmin(user);
                }
                else
                {
                    //TODO confusing flow - review initialization in general.
                    return superAdminRoles.Select(r => r.Name).ToArray();
                }
            }

            IdentityRole[] roles = await _roleRepository.GetRolesAsync(user);
            return roles.Select(r => r.Name).ToArray();
        }

        public Task<bool> IsInRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IdentityUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
