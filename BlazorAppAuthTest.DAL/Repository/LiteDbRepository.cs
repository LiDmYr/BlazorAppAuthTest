using BlazorAppAuthTest.DAL.Models;
using BlazorAppAuthTest.DAL.Options;
using LiteDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BlazorAppAuthTest.DAL
{
    public class LiteDbRepository : ILiteDbRepository, IDisposable
    {
        //TODO check - about singleton with storing collection? Does LiteDbDriver work well in that case?
        private readonly LiteDatabase _db;

        //TODO not to store external libs docs/entities - use mapper to use own
        public ILiteCollection<IdentityUser> IdentityUsers { get; }
        public ILiteCollection<IdentityRole> IdentityRoles { get; }
        public ILiteCollection<RolesForUsers> RolesForUsers { get; }

        public LiteDbRepository(IOptions<LiteDbSettings> options)
        {
            _db = new LiteDatabase(options.Value.DbFilePath);

            IdentityUsers = _db.GetCollection<IdentityUser>(nameof(IdentityUser));
            IdentityRoles = _db.GetCollection<IdentityRole>(nameof(IdentityRole));
            RolesForUsers = _db.GetCollection<RolesForUsers>(nameof(RolesForUsers));

            EnsureRolesInDb();

            //TODO
            RolesForUsers.EnsureIndex(x => x.IdentityRole);
            RolesForUsers.EnsureIndex(x => x.IdentityUser);
        }

        private void EnsureRolesInDb()
        {
            EnsureRoleInDb(UserRoles.user);
            EnsureRoleInDb(UserRoles.admin);
            EnsureRoleInDb(UserRoles.superadmin);
        }

        private void EnsureRoleInDb(UserRoles role)
        {
            string roleName = role.ToString();
            IdentityRole? identityRole = IdentityRoles.Query().Where(ir => ir.Name == roleName).FirstOrDefault();
            if (identityRole == null)
            {
                identityRole = new IdentityRole(roleName)
                {
                    NormalizedName = roleName.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                IdentityRoles.Insert(identityRole);
            }
        }

        public void Dispose()
        {
            //TODO Dispose connection
        }
    }
}
