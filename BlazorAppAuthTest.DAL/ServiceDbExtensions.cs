using BlazorAppAuthTest.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAppAuthTest.DAL
{
    public static class ServiceDbExtensions
    {
        public static void AddCustomUserRoleStores(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILiteDbRepository, LiteDbRepository>();

            serviceCollection.AddSingleton<IUserRepository, LiteDbUserRepository>();
            serviceCollection.AddSingleton<IRoleRepository, LiteDbRoleRepository>();
        }
    }
}
