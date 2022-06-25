using LiteDB;
using Microsoft.AspNetCore.Identity;

namespace BlazorAppAuthTest.DAL
{
    public class LiteDbRepository : ILiteDbRepository, IDisposable
    {
        //TODO check - about singleton with storing collection? Does LiteDbDriver work well in that case?
        private readonly LiteDatabase _db;
        public ILiteCollection<IdentityUser> IdentityUsers { get; }
        public ILiteCollection<IdentityRole> IdentityRoles { get; }

        public LiteDbRepository()
        {
            //TODO read file path from config as IOption<....>
            var conString = @"D:\workspaces\BlazorAppAuthTest\Db\liteStorage.db";
            _db = new LiteDatabase(conString);

            IdentityUsers = _db.GetCollection<IdentityUser>(nameof(IdentityUser));
            IdentityRoles = _db.GetCollection<IdentityRole>(nameof(IdentityRole));
        }

        public void Dispose()
        {
            //TODO Dispose connection
        }
    }
}
