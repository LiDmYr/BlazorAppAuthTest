using BlazorAppAuthTest.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BlazorAppAuthTest.DAL.Repository
{
    public interface IRoleRepository
    {
        Task<IdentityRole> FindByNameAsync(UserRoles role);

        Task<IdentityRole[]> GetRolesAsync(IdentityUser user);

        Task AddSuperAdmin(IdentityUser user);

        Task AddUserAsync(IdentityUser user);
    }
}