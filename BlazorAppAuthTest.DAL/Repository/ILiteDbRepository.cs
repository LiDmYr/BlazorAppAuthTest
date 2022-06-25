using LiteDB;
using Microsoft.AspNetCore.Identity;

namespace BlazorAppAuthTest.DAL
{
    public interface ILiteDbRepository
    {
        ILiteCollection<IdentityUser> IdentityUsers { get; }
        ILiteCollection<IdentityRole> IdentityRoles { get; }
    }
}
