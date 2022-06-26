using LiteDB;
using Microsoft.AspNetCore.Identity;

namespace BlazorAppAuthTest.DAL.Models
{
    // Many-to-Many
    public class RolesForUsers
    {
        //TODO Ideally combined key but is it supported by LiteDb
        public string Id => $"{IdentityUser.UserName}-{IdentityRole.Name}";

        [BsonRef(nameof(IdentityUser))]
        public IdentityUser IdentityUser { get; set; }

        [BsonRef(nameof(IdentityRole))]
        public IdentityRole IdentityRole { get; set; }
    }
}
