using LiteDB;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppAuthTest.DAL
{
    public interface ILiteDbRepository
    {
        ILiteCollection<IdentityUser> IdentityUsers { get; }
        ILiteCollection<IdentityRole> IdentityRoles { get; }
    }
}
