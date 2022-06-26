using Microsoft.AspNetCore.Identity;

namespace BlazorAppAuthTest.DAL.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(IdentityUser user);

        Task<IdentityResult> EditAsync(IdentityUser user, string newName);
        Task<IdentityUser[]> GetAllAsync();

        Task<IdentityResult> DeleteAsync(IdentityUser user);
        Task<IdentityUser> FindByIdAsync(string userId);
        Task<IdentityUser> FindByNameAsync(string userName);
        Task<IdentityUser> FindByEmailAsync(string normalizedEmail);
    }
}