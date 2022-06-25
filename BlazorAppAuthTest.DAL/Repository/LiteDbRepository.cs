using LiteDB;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppAuthTest.DAL
{
    public class LiteDbRepository : ILiteDbRepository, IDisposable
    {
        private readonly LiteDatabase _db;
        public ILiteCollection<IdentityUser> IdentityUsers { get; }
        public ILiteCollection<IdentityRole> IdentityRoles { get; }

        public LiteDbRepository()
        {
            var conString = @"D:\workspaces\BlazorAppAuthTest\Db\liteStorage.db";
            _db = new LiteDatabase(conString);

            IdentityUsers = _db.GetCollection<IdentityUser>("IdentityUser");
            IdentityRoles = _db.GetCollection<IdentityRole>("IdentityRole");
        }

        public void Dispose()
        {
            //TODO Dispose connection
        }
    }
}
