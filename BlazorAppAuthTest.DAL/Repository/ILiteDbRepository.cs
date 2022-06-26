using BlazorAppAuthTest.DAL.Models;
using LiteDB;
using Microsoft.AspNetCore.Identity;

namespace BlazorAppAuthTest.DAL
{
    public interface ILiteDbRepository
    {
        ILiteCollection<IdentityUser> IdentityUsers { get; }
        ILiteCollection<IdentityRole> IdentityRoles { get; }
        ILiteCollection<RolesForUsers> RolesForUsers { get; }
    }
}
